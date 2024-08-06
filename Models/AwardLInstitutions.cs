using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class AwardLInstitutions
    {

        [Key]
        public string ID { get; set; }
        public string AwardLeader { get; set; }
        public string Institution { get; set; }
        public string Notes { get; set; }
    }
}
