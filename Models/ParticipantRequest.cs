using ProjectManagementAPIB.DTOs;

namespace ProjectManagementAPIB.Models
{
    public class ParticipantRequest
    {
        public ParticipantDto Participant { get; set; }
        public IFormFile PassportPhoto { get; set; }
        public IFormFile Doc { get; set; }
    }
}
