using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Training
    {
        [Key]
        public int TrainingID { get; set; }
        public string TrainingName { get; set; }
        public string InstitutionName { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public string Categories { get; set; }
        public string SubCounty { get; set; }
        public string County { get; set; }
        public string Coordinator { get; set; }
        public string TrainingLevel { get; set; }
        public string TrainingType { get; set; }
        public string Notes { get; set; }
    }

}
