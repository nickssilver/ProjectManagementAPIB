using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Programm
    {
        [Key]
        public string ProgramID { get; set; }

        public string ProgramName { get; set; }
        public string InstitutionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Cost { get; set; }
        public string SubCounty { get; set; }
        public string County { get; set; }
        public string Description { get; set; }
        public string Coordinator { get; set; }
    }
}
