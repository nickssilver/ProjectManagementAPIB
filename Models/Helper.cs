using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Helper
    {
        [Key]
        public string HelperID { get; set; }
        public string HelperName { get; set; }
        public string InstitutionName { get; set; }
        public string Gender { get; set; }
        public string IdNo { get; set; }
        public string PhoneNo { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string SubCounty { get; set; }
        public string County { get; set; }
        public string HelperType { get; set; }
        public string Coordinator { get; set; }
    }

}
