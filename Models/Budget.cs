using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Budget
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Coordinator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string InstitutionName { get; set; }
        public string SubCounty { get; set; }
        public string County { get; set; }
    }

}
