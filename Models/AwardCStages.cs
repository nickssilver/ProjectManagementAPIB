﻿using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class AwardCenterStages
    {
        [Key]
        public string StageID { get; set; }
        public string StageName { get; set; }
        public string Notes { get; set; }
    }
}
