using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class SubCounty
    {
        [Key]
        public int SubCountyID { get; set; }
        public string SubCountyName { get; set; }
        public int CountyID { get; set; }

        [ForeignKey("CountyID")]
        public County County { get; set; }
    }
}
