using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementAPIB.Models
{
    public class AwardCType
    {
       
        public string AwardCTypeID { get; set; }
        public string CenterName { get; set; }
        public string Notes { get; set; }

    }
}
