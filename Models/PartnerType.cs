using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class PartnerType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string Notes { get; set; }
    }

}
