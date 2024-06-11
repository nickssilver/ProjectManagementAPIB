using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class InstitutionStatus
    {
        [Key]
        public string StatusID { get; set; }
        public string StatusName { get; set; }
        public string Notes { get; set; }
        public ICollection<Institution> Institutions { get; set; }
    }
}
