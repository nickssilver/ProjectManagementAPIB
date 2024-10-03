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
        public int ApprovalStatus { get; set; } // Optional (nullable)


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
    public class UserUpdateDTO
    {
        public string? Username { get; set; } // Optional (nullable)

        public string? Name { get; set; } // Optional (nullable)

        public int? RoleID { get; set; } // Optional (nullable)

        public string? Gender { get; set; } // Optional (nullable)

        public string? IdNo { get; set; } // Optional (nullable)

        public string? PhoneNo { get; set; } // Optional (nullable)
        public int ApprovalStatus { get; set; } // Optional (nullable)

        public string? Email { get; set; } // Optional (nullable)

        public string? Password { get; set; } // Optional (nullable)
    }

}
