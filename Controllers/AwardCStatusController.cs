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
    public class AwardCStatusController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public AwardCStatusController(ProjectManagementContext context)
        {
            _context = context;
        } 

        // GET: api/AwardCenterStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwardCenterStatus>>> GetInstitutionStatuses()
        {
            return await _context.AwardCenterStatus.ToListAsync();
        }

        // GET: api/AwardCenterStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AwardCenterStatus>> GetInstitutionStatus(string id)
        {
            var institutionStatus = await _context.AwardCenterStatus.FindAsync(id);

            if (institutionStatus == null)
            {
                return NotFound();
            }

            return institutionStatus;
        }

        // POST: api/AwardCenterStatus
        [HttpPost]
        public async Task<ActionResult<AwardCenterStatus>> PostInstitutionStatus(AwardCenterStatus institutionStatus)
        {
            _context.AwardCenterStatus.Add(institutionStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstitutionStatus), new { id = institutionStatus.StatusID }, institutionStatus);
        }

        // PUT: api/AwardCenterStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitutionStatus(string id, AwardCenterStatus institutionStatus)
        {
            if (id != institutionStatus.StatusID)
            {
                return BadRequest();
            }

            _context.Entry(institutionStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionStatusExists(id))
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

        // DELETE: api/AwardCenterStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitutionStatus(string id)
        {
            var institutionStatus = await _context.AwardCenterStatus.FindAsync(id);
            if (institutionStatus == null)
            {
                return NotFound();
            }

            _context.AwardCenterStatus.Remove(institutionStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutionStatusExists(string id)
        {
            return _context.AwardCenterStatus.Any(e => e.StatusID == id);
        }
    }
}
