using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class GroupType
    {
        [Key]
        public string GroupID { get; set; }
        public string GroupName { get; set; }
        public string Notes { get; set; }
    }
}
