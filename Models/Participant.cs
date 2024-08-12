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
        public string Age { get; set; }
        public string Religion { get; set; }
        public string Ethnicity { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string InstitutionName { get; set; }
        public string County { get; set; }
        public string SubCounty { get; set; }
        public string AwardLevel { get; set; }
        public string GuardianName { get; set; }
        public string GuardianContact { get; set; }
        public string EmergencyCName { get; set; }
        public string EmergencyCNumber { get; set; }
        public string EmergencyCRelation { get; set; }
        public string PaymentStatus { get; set; }
        public string Marginalised { get; set; }
        public string AtRisk { get; set; }
        public string Notes { get; set; }

    }

}
