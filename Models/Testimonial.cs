using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Testimonial
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }

}
