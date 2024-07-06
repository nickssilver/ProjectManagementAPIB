using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class ParticipantLevel
    {
        [Key]
        public string LevelID { get; set; }
        public string LevelName { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }
    }

}
