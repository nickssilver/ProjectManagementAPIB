using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Feedback
    {
        [Key]
        public string RespondentID { get; set; }
        public string TitleName { get; set; }
        public string Description { get; set; }
        public string RespondentType { get; set; }
        public string PhoneNo { get; set; }
        public string RespondentEmail { get; set; }
    }

}
