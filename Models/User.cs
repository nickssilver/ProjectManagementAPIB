using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ProjectManagementAPIB.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Name { get; set; }
        public string RoleID { get; set; }  // Foreign key reference
        public string Gender { get; set; }
        public string IdNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

  
    }

}
