using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class InstitutionStage
    {
        [Key]
        public string StageID { get; set; }
        public string StageName { get; set; }
        public string Notes { get; set; }
        public ICollection<Institution> Institutions { get; set; }
    }
}
