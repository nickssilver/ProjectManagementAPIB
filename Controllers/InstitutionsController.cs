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
    public class InstitutionsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public InstitutionsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/AwardCenter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwardCenter>>> GetInstitutions()
        {
            return await _context.AwardCenter.ToListAsync();
        }

        // GET: api/AwardCenter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AwardCenter>> GetInstitution(string id)
        {
            var institution = await _context.AwardCenter.FindAsync(id);

            if (institution == null)
            {
                return NotFound();
            }

            return institution;
        }

        // POST: api/AwardCenter
        [HttpPost]
        public async Task<ActionResult<AwardCenter>> PostInstitution(AwardCenter institution)
        {
            _context.AwardCenter.Add(institution);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstitution), new { id = institution.InstitutionID }, institution);
        }

        // PUT: api/AwardCenter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitution(string id, AwardCenter institution)
        {
            if (id != institution.InstitutionID)
            {
                return BadRequest();
            }

            _context.Entry(institution).State = EntityState.Modified;

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
            var institution = await _context.AwardCenter.FindAsync(id);
            if (institution == null)
            {
                return NotFound();
            }

            _context.AwardCenter.Remove(institution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutionExists(string id)
        {
            return _context.AwardCenter.Any(e => e.InstitutionID == id);
        }
    }
}
