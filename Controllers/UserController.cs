using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using ProjectManagementAPIB.DTOs;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProjectManagementContext _context;
        private readonly IConfiguration _configuration;

        public UserController(ProjectManagementContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var usersWithPermissions = await _context.Users
    .Include(u => u.Role)                       // Include the Role of the User
        .ThenInclude(r => r.PermissionRoles)    // Include the PermissionRoles of the Role
            .ThenInclude(pr => pr.Permission)   // Include the Permissions of the PermissionRoles
    .Select(u => new
    {
        u.Name,
        u.Gender,
        u.IdNo,
        u.PhoneNo,
        u.Email,
        u.Username,
        u.ApprovalStatus,
        Role = new
        {
            u.Role.Id,
            u.Role.Name,
            Permissions = u.Role.PermissionRoles
                .Select(pr => new
                {
                    pr.Permission.Id,
                    pr.Permission.Name
                }).ToList()
        }
    })
    .ToListAsync();

            return Ok(usersWithPermissions);



        }

        // GET: api/User/{username}
        // GET: api/User/{username}
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            var user = await _context.Users
                .Include(u => u.Role) // Include the Role of the User
                .Select(u => new
                {
                    u.Name,
                    u.Gender,
                    u.IdNo,
                    u.PhoneNo,
                    u.Email,
                    u.Username,
                    u.ApprovalStatus,
                    Role = new
                    {
                        u.Role.Id,
                        u.Role.Name
                        // No Permissions included here
                    }
                })
                .FirstOrDefaultAsync(u => u.Username == username); // Ensure to filter by username

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user); // Return the user wrapped in Ok()
        }

        // POST: api/User
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDTO userDto)
        {
            if (ModelState.IsValid)
            {
                // Find the role by RoleID
                var role = _context.Roles.Find(userDto.RoleID);
                if (role == null)
                {
                    return BadRequest("Invalid RoleID");
                }

                // Map DTO to the User entity
                var user = new User
                {
                    Username = userDto.Username,
                    Name = userDto.Name,
                    RoleID = userDto.RoleID,
                    Role = role,  // Setting up relationship
                    Gender = userDto.Gender,
                    IdNo = userDto.IdNo,
                    PhoneNo = userDto.PhoneNo,
                    Email = userDto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password)  // Hash the password
                };

                // Save the new user to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok(user);  // Optionally return the created user
            }

            return BadRequest(ModelState);
        }


        [HttpPut("{username}")]
        public async Task<IActionResult> PutUser(string username, [FromBody] UserUpdateDTO userDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid user data.");
            }

            // Find the existing user in the database
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            // Conditionally update the user's fields with values from the DTO
            if (!string.IsNullOrEmpty(userDto.Name))
            {
                existingUser.Name = userDto.Name;
            }

            if (userDto.ApprovalStatus >= 0) // Assuming 0 and positive numbers are valid
            {
                existingUser.ApprovalStatus = userDto.ApprovalStatus;
            }

            if (!string.IsNullOrEmpty(userDto.Gender))
            {
                existingUser.Gender = userDto.Gender;
            }

            if (!string.IsNullOrEmpty(userDto.IdNo))
            {
                existingUser.IdNo = userDto.IdNo;
            }

            if (!string.IsNullOrEmpty(userDto.PhoneNo))
            {
                existingUser.PhoneNo = userDto.PhoneNo;
            }

            if (!string.IsNullOrEmpty(userDto.Email))
            {
                existingUser.Email = userDto.Email;
            }

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                // Hash and update the password only if a new password is provided
                existingUser.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            }

            _context.Entry(existingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/User/{username}
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _context.Users.FindAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/User/Login
        [HttpPost("Login")]
        public async Task<ActionResult<object>> Login([FromBody] Login loginModel)
        {
            var user = await _context.Users
                .Include(u => u.Role)                       // Include the Role of the User
                    .ThenInclude(r => r.PermissionRoles)    // Include the PermissionRoles of the Role
                        .ThenInclude(pr => pr.Permission)   // Include the Permissions associated with the Role
                .Where(u => u.Username == loginModel.Username)
                .FirstOrDefaultAsync();

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                return Unauthorized();
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);

            // Return the token along with the user's details, role, and permissions
            return Ok(new
            {
                token,
                user = new
                {
                    user.Username,
                    user.Email,
                    user.ApprovalStatus,
                    Role = new
                    {
                        user.Role.Id,
                        user.Role.Name,
                        Permissions = user.Role.PermissionRoles
                            .Select(pr => new
                            {
                                pr.Permission.Id,
                                pr.Permission.Name
                            }).ToList()
                    }
                }
            });
        }


        // reset password
        // POST: api/User/RequestPasswordReset
        [HttpPost("RequestPasswordReset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] PasswordResetRequestModel model)
        {
            // Look for a user with the provided email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                return NotFound("User with the provided email not found.");
            }

            // Generate reset token
            var token = GenerateEncryptedToken(user);

            // Send the reset email
            await SendPasswordResetEmail(user.Email, token);

            return Ok("Password reset email sent successfully.");
        }

        //password update endpoint 
        // PUT: api/User/ResetPassword
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetModel model)
        {
            if (string.IsNullOrEmpty(model.Token) || string.IsNullOrEmpty(model.NewPassword))
            {
                return BadRequest("Token and new password are required.");
            }

            // Decrypt the token to retrieve username and email
            var (username, email) = DecryptEncryptedToken(model.Token);
            if (username == null || email == null)

            {
                return BadRequest("token invalid or expired");
            }

            // Find the user in the database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Email == email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Update the password (hash it before saving)
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Password has been reset successfully.");
        }


        private string GenerateEncryptedToken(User user)
        {
            var plainText = $"{user.Username}|{user.Email}|{DateTime.UtcNow.AddHours(1)}"; // Concatenate the claims

            // Encrypt using AES
            var key = Encoding.UTF8.GetBytes(_configuration["EncryptionKey"]); // Use a key from config
            var iv = new byte[16]; // Initialization vector (IV) of size 16 bytes (AES block size)
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    var plainBytes = Encoding.UTF8.GetBytes(plainText);
                    var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                    var token = Convert.ToBase64String(encryptedBytes);
                    var urlEncodedToken = Uri.EscapeDataString(token);
                    return urlEncodedToken;
                }
            }
        }

        private (string Username, string Email) DecryptEncryptedToken(string token)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["EncryptionKey"]); // Same key used in encryption
            var iv = new byte[16]; // IV should be the same (zeros in this case)

            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    try
                    {
                        var urlDecodedToken = Uri.UnescapeDataString(token);
                        var encryptedBytes = Convert.FromBase64String(urlDecodedToken);
                        var decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                        var decryptedText = Encoding.UTF8.GetString(decryptedBytes);
                        // Decrypted text is in the format: "username:email:expiry"
                        var parts = decryptedText.Split('|');
                        var username = parts[0];
                        var email = parts[1];
                        var expiry = DateTime.Parse(parts[2]);

                        // Validate token expiration
                        if (expiry > DateTime.UtcNow)
                        {
                            return (username, email); // Return the claims
                        }
                        else
                        {
                            Console.WriteLine("The token has expired.");
                            return (null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Token decryption failed: {ex.Message}");
                        return (null, null);
                    }
                }
            }
        }

        private string GenerateJwtToken(dynamic user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Username),
               // new Claim(ClaimTypes.Role, user.RoleID)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(e => e.Username == username);
        }

        private async Task SendPasswordResetEmail(string email, string token)
        {
            var resetPasswordLink = $"http://localhost:3000/change-password?token={token}";

            var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Smtp:Username"]),
                Subject = "Password Reset Request",
                Body = $@"
            <div style='font-family: Arial, sans-serif; padding: 20px;'>
                <h1 style='color: #007bff;'>Password Reset Request</h1>
                <p>Hi there,</p>
                <p>We received a request to reset your password. Click the button below to proceed with the password reset process:</p>
                <a href='{resetPasswordLink}' style='display: inline-block; background-color: #2B3674; color: #fff; text-decoration: none; padding: 10px 20px; border-radius: 5px;'>Reset Password</a>
                <p>If you didn't request this, you can safely ignore this email.</p>
                <p>Thanks,<br/>PAK</p>
            </div>
        ",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error sending password reset email: {ex.Message}");
            }
        }

    }
}
