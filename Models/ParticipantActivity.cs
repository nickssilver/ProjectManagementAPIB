using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class ParticipantActivity
    {
        [Key] 
        public string ID {  get; set; }
        public string AdminNumber { get; set;}
        public string StudentName { get; set;}
        public string InstitutionName { get; set; }
        public string ProjectName { get; set;}
        public string ActivityName { get; set; }

    }
}
