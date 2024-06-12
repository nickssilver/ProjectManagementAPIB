using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class TrainingLevel
    {
        [Key]
        public int TrainingLevelID { get; set; }
        public string LevelName { get; set; }
        public string Notes { get; set; }
    }

}
