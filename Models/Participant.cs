using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Participant
    {
        [Key]
        public string AdminNumber { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string InstitutionName { get; set; }
        public string SubCounty { get; set; }
        public string County { get; set; }
        public string AwardLevel { get; set; }
        public string AwardLeader { get; set; }
    }

}
