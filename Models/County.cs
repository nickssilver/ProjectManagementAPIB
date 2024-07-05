using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class County
    {
        [Key]
        [Required]
        public int CountyID { get; set; }
        public string CountyName { get; set; }

        public ICollection<SubCounty> SubCounties { get; set; }

    }
}
