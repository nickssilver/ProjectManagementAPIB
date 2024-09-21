using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int RoleID { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string IdNo { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }

}
