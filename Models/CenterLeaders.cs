using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class CenterLeaders
    {

        [Key]
        public string ID { get; set; }
        public string AwardLeader { get; set; }
        public string Award { get; set; }
        public string Notes { get; set; }
    }
}
