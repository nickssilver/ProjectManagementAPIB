using System.Collections.Generic;

namespace ProjectManagementAPIB.Models
{
    public class InstitutionStage
    {
        public int StageID { get; set; }
        public string StageName { get; set; }
        public string Notes { get; set; }
        public ICollection<Institution> Institutions { get; set; }
    }
}
