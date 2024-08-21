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
        public async Task<ActionResult<ActivityApproval>> PostActivityApproval(ActivityApproval activityApproval)
        {
            _context.ActivityApprovals.Add(activityApproval);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivityApproval), new { id = activityApproval.ID }, activityApproval);
        }

        // PUT: api/ActivityApproval/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityApproval(int id, ActivityApproval activityApproval)
        {
            if (id != activityApproval.ID)
            {
                return BadRequest();
            }

            _context.Entry(activityApproval).State = EntityState.Modified;

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
