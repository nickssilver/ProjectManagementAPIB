using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementAPIB.Models
{
    public class CenterLeaders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string AwardLeader { get; set; }
        public string Institution { get; set; }
        public string Notes { get; set; }
    }
}
