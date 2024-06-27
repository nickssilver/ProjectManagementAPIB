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
    public class InstitutionStagesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public InstitutionStagesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/InstitutionStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstitutionStage>>> GetInstitutionStages()
        {
            return await _context.InstitutionStages.ToListAsync();
        }

        // GET: api/InstitutionStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstitutionStage>> GetInstitutionStage(string id)
        {
            var institutionStage = await _context.InstitutionStages.FindAsync(id);

            if (institutionStage == null)
            {
                return NotFound();
            }

            return institutionStage;
        }

        // POST: api/InstitutionStages
        [HttpPost]
        public async Task<ActionResult<InstitutionStage>> PostInstitutionStage(InstitutionStage institutionStage)
        {
            _context.InstitutionStages.Add(institutionStage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstitutionStage), new { id = institutionStage.StageID }, institutionStage);
        }

        // PUT: api/InstitutionStages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitutionStage(string id, InstitutionStage institutionStage)
        {
            if (id != institutionStage.StageID)
            {
                return BadRequest();
            }

            _context.Entry(institutionStage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionStageExists(id))
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

        // DELETE: api/InstitutionStages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitutionStage(string id)
        {
            var institutionStage = await _context.InstitutionStages.FindAsync(id);
            if (institutionStage == null)
            {
                return NotFound();
            }

            _context.InstitutionStages.Remove(institutionStage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutionStageExists(string id)
        {
            return _context.InstitutionStages.Any(e => e.StageID == id);
        }
    }
}
