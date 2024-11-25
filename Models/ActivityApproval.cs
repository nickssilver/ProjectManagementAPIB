using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class ActivityApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string AwardCentre { get; set; }
        public string AwardLeader { get; set; }
        public string ActivityName { get; set; }
        public string ParticipantsNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime ApplyDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActivityDate { get; set; }
        public string Region { get; set; }
        public bool Consent { get; set; }
        public string Assessors { get; set; }
        public string Assessors2 { get; set; }
        public string Assessors3 { get; set; }
        public string UploadForm { get; set; }
        public string? UploadForm2 { get; set; }
        public string? UploadForm3 { get; set; }
        public string Approval { get; set; }
        public string Notes { get; set; }
    }
}
