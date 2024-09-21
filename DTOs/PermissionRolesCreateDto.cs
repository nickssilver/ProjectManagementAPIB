using System.ComponentModel.DataAnnotations;
using ProjectManagementAPIB.image.Models;

namespace ProjectManagementAPIB.DTOs
{
    public class PermissionRolesCreateDto
    {

        [Required]
        public int PermissionId { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
    public class PermissionWithRolesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<Roles> Roles { get; set; } = new List<Roles>();
    }

}
