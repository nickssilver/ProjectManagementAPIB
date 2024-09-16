using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Partnership
    {
        [Key]
        public string PartnerID { get; set; }
        public string PartnerName { get; set; }
        public string PartnerEmail { get; set; }
        public string PhoneNo { get; set; }
        public string PartnerType { get; set; }
    }

}
