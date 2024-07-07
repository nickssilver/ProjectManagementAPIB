using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class ParticipantProject
    {
        [Key] 
        public string ParticipantID {  get; set; }
        public string ParticipantName { get; set;}
        public string InstitutionName { get; set;}
        public string ProjectID { get; set;}
    }
}
