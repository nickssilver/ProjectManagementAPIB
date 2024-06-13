using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class ProjectStatus
    {
        [Key]
        public string ProjectStatusID { get; set; }
        public string StatusName { get; set; }
        public string Notes { get; set; }
    }

}
