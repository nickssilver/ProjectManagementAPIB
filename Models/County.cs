using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class County
    {
        [Key]
        public int CountyID { get; set; }
        public string SubCounty { get; set; }
        public string CountyName { get; set; }
        public string Region { get; set; }
        public string Notes { get; set; }
        public ICollection<Institution> Institutions { get; set; }
    }
}
