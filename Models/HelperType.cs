using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class HelperType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string Notes { get; set; }
    }

}
