using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Level
    {
        [Key]
        public string LevelID { get; set; }
        public string LevelName { get; set; }
        public string Notes { get; set; }
    }

}
