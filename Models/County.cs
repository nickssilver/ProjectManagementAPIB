using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class County
    {
        [Required]
        public string CountyID { get; set; }
        public string CountyName { get; set; }
        public string SubCounty { get; set; }
        public string Region { get; set; }
        public string Notes { get; set; }
    }
}
