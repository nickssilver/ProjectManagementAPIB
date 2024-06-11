using System.Collections.Generic;

namespace ProjectManagementAPIB.Models
{
    public class InstitutionStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string Notes { get; set; }
        public ICollection<Institution> Institutions { get; set; }
    }
}
