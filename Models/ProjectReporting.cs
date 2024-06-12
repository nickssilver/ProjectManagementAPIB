using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class ProjectReporting
    {
        [Key]
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }

}
