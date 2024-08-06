using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class AwardCStatus
    {
        [Key]
        public string StatusID { get; set; }
        public string StatusName { get; set; }
        public string Notes { get; set; }
    }
}
