using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace ProjectManagementAPIB.Models
{
    public class Institution
    {
        public int InstitutionID { get; set; }
        public string InstitutionName { get; set; }
        public int StageID { get; set; }
        public InstitutionStage Stage { get; set; }
        public int StatusID { get; set; }
        public InstitutionStatus Status { get; set; }
        public string InstitutionEmail { get; set; }
        public string InstitutionContact { get; set; }
        public string SubCounty { get; set; }
        public int CountyID { get; set; }
        public County County { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public DateTime LicenseStartDate { get; set; }
        public DateTime LicenseEndDate { get; set; }
        public string AwardLeader { get; set; }
        public string Notes { get; set; }
    }
}
