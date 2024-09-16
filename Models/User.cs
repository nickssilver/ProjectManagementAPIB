using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;

namespace ProjectManagementAPIB.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Name { get; set; }
        public string RoleID { get; set; }
        public string Gender { get; set; }
        public string IdNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

      
    }
    public class PasswordResetRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class PasswordResetModel
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}