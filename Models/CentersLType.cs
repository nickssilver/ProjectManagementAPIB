using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class CentersLType
    {
        [Key]
        public string ID { get; set; }
        public string LevelName { get; set; }
        public string Notes { get; set; }

    }
}
