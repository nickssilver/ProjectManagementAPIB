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
        public string UploadForm { get; set; }
        public bool Consent { get; set; }
        public string Notes { get; set; }
    }
}
