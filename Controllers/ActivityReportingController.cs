using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityReportingController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ActivityReportingController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/ActivityReporting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityReporting>>> GetActivityReports()
        {
            return await _context.ActivityReporting.ToListAsync();
        }

        // GET: api/ActivityReporting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityReporting>> GetActivityReport(int id)
        {
            var activityReport = await _context.ActivityReporting.FindAsync(id);

            if (activityReport == null)
            {
                return NotFound();
            }

            return activityReport;
        }

        // POST: api/ActivityReporting
        [HttpPost]
        public async Task<ActionResult<ActivityReporting>> PostActivityReport([FromForm] ActivityReportingRequest activityReportRequest)
        { 
              var uploadReportFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads", "upload-report");

            // Ensure directories exist for saving uploaded files
            if (!Directory.Exists(uploadReportFolder)) Directory.CreateDirectory(uploadReportFolder);

                var activityReporting = new ActivityReporting
                {
                    AwardCentre = activityReportRequest.AwardCentre,
                    AwardLeader = activityReportRequest.AwardLeader,
                    ActivityName = activityReportRequest.ActivityName,
                    ParticipantsNo = activityReportRequest.ParticipantsNo,
                    Region = activityReportRequest.Region,
                    Notes = activityReportRequest.Notes,
                };

            if (activityReportRequest.UploadReport != null && activityReportRequest.UploadReport.Length > 0)
            {
                var originalFileName = activityReportRequest.UploadReport.FileName;
                    var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    var uploadReportFileName = $"{Path.GetFileNameWithoutExtension(originalFileName)}_{timestamp}{Path.GetExtension(originalFileName)}";
                    var uploadReport = Path.Combine(uploadReportFolder, uploadReportFileName);

                // Save file to server
                using (var stream = new FileStream(uploadReport, FileMode.Create))
                    {
                    await activityReportRequest.UploadReport.CopyToAsync(stream);
                    }

                activityReporting.UploadReport = $"/uploads/upload-report/{uploadReportFileName}";

            }
                _context.ActivityReporting.Add(activityReporting);
                await _context.SaveChangesAsync();

                // Return created response
                return CreatedAtAction("GetActivityReport", new { id = activityReporting.ID }, activityReporting);
        }

        // PUT: api/ActivityReporting/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityReport(int id, ActivityReporting activityReport)
        {
            if (id != activityReport.ID)
            {
                return BadRequest();
            }

            _context.Entry(activityReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityReportExists(id))
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

        // DELETE: api/ActivityReporting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityReport(int id)
        {
            var activityReport = await _context.ActivityReporting.FindAsync(id);
            if (activityReport == null)
            {
                return NotFound();
            }

            _context.ActivityReporting.Remove(activityReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityReportExists(int id)
        {
            return _context.ActivityReporting.Any(e => e.ID == id);
        }
    }
}
