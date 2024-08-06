using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class AwardCenterStatus
    {
        [Key]
        public string StatusID { get; set; }
        public string StatusName { get; set; }
        public string Notes { get; set; }
    }
}
