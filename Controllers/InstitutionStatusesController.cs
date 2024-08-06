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
    public class InstitutionStatusesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public InstitutionStatusesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/InstitutionStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwardCStatus>>> GetInstitutionStatuses()
        {
            return await _context.InstitutionStatuses.ToListAsync();
        }

        // GET: api/InstitutionStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AwardCStatus>> GetInstitutionStatus(string id)
        {
            var institutionStatus = await _context.InstitutionStatuses.FindAsync(id);

            if (institutionStatus == null)
            {
                return NotFound();
            }

            return institutionStatus;
        }

        // POST: api/InstitutionStatuses
        [HttpPost]
        public async Task<ActionResult<AwardCStatus>> PostInstitutionStatus(AwardCStatus institutionStatus)
        {
            _context.InstitutionStatuses.Add(institutionStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstitutionStatus), new { id = institutionStatus.StatusID }, institutionStatus);
        }

        // PUT: api/InstitutionStatuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitutionStatus(string id, AwardCStatus institutionStatus)
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

        // DELETE: api/InstitutionStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitutionStatus(string id)
        {
            var institutionStatus = await _context.InstitutionStatuses.FindAsync(id);
            if (institutionStatus == null)
            {
                return NotFound();
            }

            _context.InstitutionStatuses.Remove(institutionStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutionStatusExists(string id)
        {
            return _context.InstitutionStatuses.Any(e => e.StatusID == id);
        }
    }
}
