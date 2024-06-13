using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class FundingType
    {
        [Key]
        public string FundingID { get; set; }
        public string FundingName { get; set; }
        public string Notes { get; set; }
    }

}
