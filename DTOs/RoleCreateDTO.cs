using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.DTOs
{
    public class RoleCreateDTO
    {

        [Required]
        public string Name { get; set; }

    }
    public class RoleWithPermissionsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PermissionDTO> Permissions { get; set; } = new List<PermissionDTO>();
    }
}
