using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class SettingsRequest
    {
        public string? Profile { get; set; }
        public string? LegalName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? TaxNo { get; set; }
        public string? Contact { get; set; }
        public string?  Footer { get; set; }
        public IFormFile? Logo { get; set; }

    }
}
