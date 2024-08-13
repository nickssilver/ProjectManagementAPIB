using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementAPIB.Models
{
    public class ParticipantActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string AdminNumber { get; set;}
        public string StudentName { get; set;}
        public string InstitutionName { get; set; }
        public string ActivityName { get; set; }

    }
}
