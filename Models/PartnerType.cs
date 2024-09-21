using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class PartnerType
    {
        [Key]
        public string TypeID { get; set; }
        public string TypeName { get; set; }
        public string Notes { get; set; }
    }

}
