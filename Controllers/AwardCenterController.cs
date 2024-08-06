using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardCenterController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public AwardCenterController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/AwardCenter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwardCenter>>> GetInstitutions()
        {
            return await _context.AwardCenters.ToListAsync();
        }

        // GET: api/AwardCenter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AwardCenter>> GetInstitution(string id)
        {
            var award = await _context.AwardCenters.FindAsync(id);

            if (award == null)
            {
                return NotFound();
            }

            return award;
        }

        // POST: api/AwardCenter
        [HttpPost]
        public async Task<ActionResult<AwardCenter>> PostInstitution(AwardCenter award)
        {
            _context.AwardCenters.Add(award);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstitution), new { id = award.InstitutionID }, award);
        }

        // PUT: api/AwardCenter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitution(string id, AwardCenter award)
        {
            if (id != award.InstitutionID)
            {
                return BadRequest();
            }

            _context.Entry(award).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionExists(id))
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

        // DELETE: api/AwardCenter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution(string id)
        {
            var award = await _context.AwardCenters.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            _context.AwardCenters.Remove(award);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutionExists(string id)
        {
            return _context.AwardCenters.Any(e => e.InstitutionID == id);
        }
    }
}
