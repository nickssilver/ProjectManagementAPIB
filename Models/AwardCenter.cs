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

        // Foreign Key for Stage
        [ForeignKey("AwardCenterStage")]
        public string StageID { get; set; }
        public virtual AwardCenterStages AwardCenterStage { get; set; } // Navigation property

        // Foreign Key for Status
        [ForeignKey("AwardCenterStatus")]
        public string StatusID { get; set; }
        public virtual AwardCenterStatus AwardCenterStatus { get; set; }

        // Foreign Key for AwardCType
        [ForeignKey("AwardCType")]
        public int AwardCTypeID { get; set; }
        public virtual AwardCType AwardCType { get; set; }

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
