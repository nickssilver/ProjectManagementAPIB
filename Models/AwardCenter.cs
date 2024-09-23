using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementAPIB.Models
{
    public class AwardCenter
    {
        [Key]
        public string InstitutionID { get; set; }
        public string InstitutionName { get; set; }
        public string StageID { get; set; }
        public string StatusID { get; set; }
        public string AwardCTypeID { get; set; }
        public string InstitutionEmail { get; set; }
        public string InstitutionContact { get; set; }
        public string Region { get; set; }
        public string SubCounty { get; set; }
        public string County { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime LicenseStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LicenseEndDate { get; set; }

        public string Source { get; set; }
        public string Marginalised { get; set; }
        public string Notes { get; set; }

    }
}
