using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }
        public string DonorName { get; set; }
        public string Contact { get; set; }
        public string Notes { get; set; }
    }

}
