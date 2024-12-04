using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Project
    {
        [Key]
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionName2 { get; set; }
        public string InstitutionName3 { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public decimal Cost { get; set; }
        public string Region { get; set; }
        public string Status { get; set; }
        public string SubCounty { get; set; }
        public string County { get; set; }
        public string Description { get; set; }
        public string Coordinator { get; set; }
        public string Notes { get; set; }
    }

}
