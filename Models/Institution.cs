using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class Institution
    {
        [Key]
        public string InstitutionID { get; set; }
        public string InstitutionName { get; set; }
        public string StageID { get; set; }
        public string StatusID { get; set; }
        public string InstitutionEmail { get; set; }
        public string InstitutionContact { get; set; }
        public string SubCounty { get; set; }
        public string CountyID { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime LicenseStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LicenseEndDate { get; set; }

        public string AwardLeader { get; set; }
        public string Notes { get; set; }
    }
}
