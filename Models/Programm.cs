using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Programm
    {
        [Key]
        public string ProgramID { get; set; }
        public string ProgramName { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
