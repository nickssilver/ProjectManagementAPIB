using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementAPIB.Models
{
    public class ParticipantActivityRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string AdminNumber { get; set;}
        public string StudentName { get; set;}
        public string AwardLevel { get; set; }
        public string AwardCenter { get; set; }
        public string ActivityName { get; set; }
        public IFormFile MedicalForm { get; set; }
        public string Notes { get; set; }

    }
}
