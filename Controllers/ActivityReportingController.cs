using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
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
        public async Task<ActionResult<ActivityReporting>> PostActivityReport(ActivityReporting activityReport)
        {
            _context.ActivityReporting.Add(activityReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivityReport), new { id = activityReport.ID }, activityReport);
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
