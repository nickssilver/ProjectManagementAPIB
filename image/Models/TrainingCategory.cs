using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class TrainingCategory
    {
        [Key]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Notes { get; set; }
    }

}
