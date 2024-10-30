namespace ProjectManagementAPIB.DTOs
{
    public class ActivityApprovalDTO
    {
        public string? AwardCentre { get; set; }
        public string? AwardLeader { get; set; }
        public string? ActivityName { get; set; }
        public string? ParticipantsNo { get; set; }
        public DateTime? ApplyDate { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string? Region { get; set; }
        public bool? Consent { get; set; }
        public string? Assessors { get; set; }
        public string? Assessors2 { get; set; }
        public string? Assessors3 { get; set; }
        public string? UploadForm { get; set; }
        public string? Approval { get; set; }
        public string? Notes { get; set; }
    }
}
