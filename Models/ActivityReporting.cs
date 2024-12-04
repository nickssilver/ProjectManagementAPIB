using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class ActivityReporting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string AwardCentre { get; set; }
        public string AwardLeader { get; set; }
        public string ActivityName { get; set; }
        public string ParticipantsNo { get; set; }
        public string Region { get; set; }
        public string UploadReport { get; set; }
        public string? UploadReport2 { get; set; }
        public string? UploadReport3 { get; set; }
        public string Notes { get; set; }
    }
}
