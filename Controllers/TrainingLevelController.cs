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
    public class TrainingLevelController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public TrainingLevelController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/TrainingLevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingLevel>>> GetTrainingLevels()
        {
            return await _context.TrainingLevels.ToListAsync();
        }

        // GET: api/TrainingLevel/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingLevel>> GetTrainingLevel(int id)
        {
            var trainingLevel = await _context.TrainingLevels.FindAsync(id);

            if (trainingLevel == null)
            {
                return NotFound();
            }

            return trainingLevel;
        }

        // POST: api/TrainingLevel
        [HttpPost]
        public async Task<ActionResult<TrainingLevel>> PostTrainingLevel(TrainingLevel trainingLevel)
        {
            _context.TrainingLevels.Add(trainingLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingLevel", new { id = trainingLevel.TrainingLevelID }, trainingLevel);
        }

        // PUT: api/TrainingLevel/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingLevel(string id, TrainingLevel trainingLevel)
        {
            if (id != trainingLevel.TrainingLevelID)
            {
                return BadRequest();
            }

            _context.Entry(trainingLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingLevelExists(id))
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

        // DELETE: api/TrainingLevel/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingLevel(string id)
        {
            var trainingLevel = await _context.TrainingLevels.FindAsync(id);
            if (trainingLevel == null)
            {
                return NotFound();
            }

            _context.TrainingLevels.Remove(trainingLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingLevelExists(string id)
        {
            return _context.TrainingLevels.Any(e => e.TrainingLevelID == id);
        }
    }
}
