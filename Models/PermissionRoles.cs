using System.Text.Json.Serialization;

namespace ProjectManagementAPIB.image.Models
{
    public class PermissionRoles
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public Permissions Permission { get; set; }
        [JsonIgnore]
        public Roles Role { get; set; }
    }
}
