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
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/{username}
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            var user = await _context.Users.FindAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            // Hash the password before saving
            if (!string.IsNullOrEmpty(user.Password) && !user.Password.StartsWith("$2a$"))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { username = user.Username }, user);
        }

        // PUT: api/User/{username}
        [HttpPut("{username}")]
        public async Task<IActionResult> PutUser(string username, User user)
        {
            if (username != user.Username)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

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
                .Where(u => u.Username == loginModel.Username)
                .Select(u => new
                {
                    u.Username,
                    u.Password,
                    u.Email,
                    u.RoleID
                })
                .FirstOrDefaultAsync();

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                return Unauthorized();
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);

            // Return both token and user details
            return Ok(new
            {
                token,
                user = new
                {
                    user.Username,
                    user.Email,
                    user.RoleID
                }
            });
        }

        private string GenerateJwtToken(dynamic user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.RoleID)
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
    }
}
