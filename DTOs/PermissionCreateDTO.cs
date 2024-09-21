using ProjectManagementAPIB.image.Models;
using ProjectManagementAPIB.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagementAPIB.DTOs
{
    public class PermissionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Notes { get; set; }


        // Navigation property for many-to-many with roles
        [JsonIgnore]
        public ICollection<PermissionRoles> PermissionRoles { get; set; } = new List<PermissionRoles>();
    }

    public class PermissionCreateDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
