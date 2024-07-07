using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class ParticipantAward
    {
        [Key]
        public string AwardID { get; set; }
        public string AdminNo { get; set; }
        public string StudentName { get; set; }
        public string InstitutionName {  get; set; }
        public string LevelName {  get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }


    }
}
