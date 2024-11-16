using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.DTOs;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityApprovalController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ActivityApprovalController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/ActivityApproval
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityApproval>>> GetActivityApprovals()
        {
            return await _context.ActivityApprovals.ToListAsync();
        }

        // GET: api/ActivityApproval/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityApproval>> GetActivityApproval(int id)
        {
            var activityApproval = await _context.ActivityApprovals.FindAsync(id);

            if (activityApproval == null)
            {
                return NotFound();
            }

            return activityApproval;
        }

        // POST: api/ActivityApproval
        [HttpPost]
        public async Task<ActionResult<ActivityApproval>> PostActivityApproval([FromForm] ActivityApprovalRequest activityApprovalRequest)
        {
            // Define the folder path for storing uploaded documents
            var docsFolder = Path.Combine(Directory.GetCurrentDirectory(),  "uploads", "activity_forms");

            // Ensure the directory exists for saving uploaded files
            if (!Directory.Exists(docsFolder)) Directory.CreateDirectory(docsFolder);

            // Create a new ActivityApproval instance to store the data
            var activityApproval = new ActivityApproval
            {
                AwardCentre = activityApprovalRequest.AwardCentre,
                AwardLeader = activityApprovalRequest.AwardLeader,
                ActivityName = activityApprovalRequest.ActivityName,
                ParticipantsNo = activityApprovalRequest.ParticipantsNo,
                ApplyDate = activityApprovalRequest.ApplyDate,
                ActivityDate = activityApprovalRequest.ActivityDate,
                Region = activityApprovalRequest.Region,
                Consent = activityApprovalRequest.Consent,
                Assessors = activityApprovalRequest.Assessors ?? "Default Assessor",
                Assessors2 = activityApprovalRequest.Assessors2 ?? "Default Assessor 2",
                Assessors3 = activityApprovalRequest.Assessors3 ?? "Default Assessor 3",
                Approval = activityApprovalRequest.Approval,
                Notes = activityApprovalRequest.Notes,
            };

            // Handle Document Upload
            if (activityApprovalRequest.UploadForm != null && activityApprovalRequest.UploadForm.Length > 0)
            {
                var originalDocFileName = activityApprovalRequest.UploadForm.FileName;

                // Create a timestamped file name
                var docTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var docFileName = $"{Path.GetFileNameWithoutExtension(originalDocFileName)}_{docTimestamp}{Path.GetExtension(originalDocFileName)}";

                var docFilePath = Path.Combine(docsFolder, docFileName);

                // Save the file to the server
                using (var stream = new FileStream(docFilePath, FileMode.Create))
                {
                    await activityApprovalRequest.UploadForm.CopyToAsync(stream);
                }

                // Store relative file path in the activityApproval model
                activityApproval.UploadForm = $"/uploads/activity_forms/{docFileName}";
            }

            //second document upload
            if (activityApprovalRequest.UploadForm2 != null && activityApprovalRequest.UploadForm2.Length > 0)
            {
                var originalDocFileName = activityApprovalRequest.UploadForm2.FileName;

                // Create a timestamped file name
                var docTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var docFileName = $"{Path.GetFileNameWithoutExtension(originalDocFileName)}_{docTimestamp}{Path.GetExtension(originalDocFileName)}";

                var docFilePath = Path.Combine(docsFolder, docFileName);

                // Save the file to the server
                using (var stream = new FileStream(docFilePath, FileMode.Create))
                {
                    await activityApprovalRequest.UploadForm2.CopyToAsync(stream);
                }

                // Store relative file path in the activityApproval model
                activityApproval.UploadForm = $"/uploads/activity_forms/{docFileName}";
            }

            //third upload
            if (activityApprovalRequest.UploadForm3 != null && activityApprovalRequest.UploadForm3.Length > 0)
            {
                var originalDocFileName = activityApprovalRequest.UploadForm3.FileName;

                // Create a timestamped file name
                var docTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var docFileName = $"{Path.GetFileNameWithoutExtension(originalDocFileName)}_{docTimestamp}{Path.GetExtension(originalDocFileName)}";

                var docFilePath = Path.Combine(docsFolder, docFileName);

                // Save the file to the server
                using (var stream = new FileStream(docFilePath, FileMode.Create))
                {
                    await activityApprovalRequest.UploadForm3.CopyToAsync(stream);
                }

                // Store relative file path in the activityApproval model
                activityApproval.UploadForm3 = $"/uploads/activity_forms/{docFileName}";
            }

            // Save activity approval to the database
            _context.ActivityApprovals.Add(activityApproval);
            await _context.SaveChangesAsync();

            // Return created response
            return CreatedAtAction(nameof(GetActivityApproval), new { id = activityApproval.ID }, activityApproval);
        }

        // PUT: api/ActivityApproval/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PatchActivityApproval(int id, [FromForm] ActivityApprovalDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid activity approval data.");
            }

            // Find the existing activity approval in the database
            var existingActivityApproval = await _context.ActivityApprovals.FirstOrDefaultAsync(a => a.ID == id);
            if (existingActivityApproval == null)
            {
                return NotFound("Activity approval not found.");
            }

            // Conditionally update fields if they are provided in the DTO
            if (!string.IsNullOrEmpty(updateDto.AwardCentre))
            {
                existingActivityApproval.AwardCentre = updateDto.AwardCentre;
            }

            if (!string.IsNullOrEmpty(updateDto.AwardLeader))
            {
                existingActivityApproval.AwardLeader = updateDto.AwardLeader;
            }

            if (!string.IsNullOrEmpty(updateDto.ActivityName))
            {
                existingActivityApproval.ActivityName = updateDto.ActivityName;
            }

            if (!string.IsNullOrEmpty(updateDto.ParticipantsNo))
            {
                existingActivityApproval.ParticipantsNo = updateDto.ParticipantsNo;
            }

            if (updateDto.ApplyDate.HasValue)
            {
                existingActivityApproval.ApplyDate = updateDto.ApplyDate.Value;
            }

            if (updateDto.ActivityDate.HasValue)
            {
                existingActivityApproval.ActivityDate = updateDto.ActivityDate.Value;
            }

            if (!string.IsNullOrEmpty(updateDto.Region))
            {
                existingActivityApproval.Region = updateDto.Region;
            }

            if (updateDto.Consent.HasValue)
            {
                existingActivityApproval.Consent = updateDto.Consent.Value;
            }

            if (!string.IsNullOrEmpty(updateDto.Assessors))
            {
                existingActivityApproval.Assessors = updateDto.Assessors;
            }

            if (!string.IsNullOrEmpty(updateDto.Assessors2))
            {
                existingActivityApproval.Assessors2 = updateDto.Assessors2;
            }

            if (!string.IsNullOrEmpty(updateDto.Assessors3))
            {
                existingActivityApproval.Assessors3 = updateDto.Assessors3;
            }

            if (!string.IsNullOrEmpty(updateDto.UploadForm))
            {
                existingActivityApproval.UploadForm = updateDto.UploadForm;
            }

            if (!string.IsNullOrEmpty(updateDto.Approval))
            {
                existingActivityApproval.Approval = updateDto.Approval;
            }

            if (!string.IsNullOrEmpty(updateDto.Notes))
            {
                existingActivityApproval.Notes = updateDto.Notes;
            }

            _context.Entry(existingActivityApproval).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityApprovalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ActivityApproval/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityApproval(int id)
        {
            var activityApproval = await _context.ActivityApprovals.FindAsync(id);
            if (activityApproval == null)
            {
                return NotFound();
            }

            _context.ActivityApprovals.Remove(activityApproval);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityApprovalExists(int id)
        {
            return _context.ActivityApprovals.Any(e => e.ID == id);
        }
    }
}
