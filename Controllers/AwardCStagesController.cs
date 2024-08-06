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
    public class AwardCStagesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public AwardCStagesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/AwardCenterStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwardCenterStages>>> GetInstitutionStages()
        {
            return await _context.AwardCenterStages.ToListAsync();
        }

        // GET: api/AwardCenterStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AwardCenterStages>> GetInstitutionStage(string id)
        {
            var awardStage = await _context.AwardCenterStages.FindAsync(id);

            if (awardStage == null)
            {
                return NotFound();
            }

            return awardStage;
        }

        // POST: api/AwardCenterStages
        [HttpPost]
        public async Task<ActionResult<AwardCenterStages>> PostInstitutionStage(AwardCenterStages awardStage)
        {
            _context.AwardCenterStages.Add(awardStage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstitutionStage), new { id = awardStage.StageID }, awardStage);
        }

        // PUT: api/AwardCenterStages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitutionStage(string id, AwardCenterStages awardStage)
        {
            if (id != awardStage.StageID)
            {
                return BadRequest();
            }

            _context.Entry(awardStage).State = EntityState.Modified;

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

        // DELETE: api/AwardCenterStages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitutionStage(string id)
        {
            var awardStage = await _context.AwardCenterStages.FindAsync(id);
            if (awardStage == null)
            {
                return NotFound();
            }

            _context.AwardCenterStages.Remove(awardStage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutionStageExists(string id)
        {
            return _context.AwardCenterStages.Any(e => e.StageID == id);
        }
    }
}
