using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class FundingType
    {
        [Key]
        public int FundingID { get; set; }
        public string FundingName { get; set; }
        public string Notes { get; set; }
    }

}
