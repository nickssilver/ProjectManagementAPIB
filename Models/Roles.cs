using ProjectManagementAPIB.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectManagementAPIB.image.Models
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]  // Ensure the Name field is required
        public string Name { get; set; }

        // Navigation property for one-to-many with users
        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();

        // Navigation property for many-to-many with permissions
        public ICollection<PermissionRoles> PermissionRoles { get; set; } = new List<PermissionRoles>();
    }
    public class RolesCreate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]  // Ensure the Name field is required
        public string Name { get; set; }
    }
}
