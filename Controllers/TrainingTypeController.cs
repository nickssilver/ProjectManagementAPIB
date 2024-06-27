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
    public class TrainingTypeController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public TrainingTypeController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/TrainingType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingType>>> GetTrainingTypes()
        {
            return await _context.TrainingTypes.ToListAsync();
        }

        // GET: api/TrainingType/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingType>> GetTrainingType(string id)
        {
            var trainingType = await _context.TrainingTypes.FindAsync(id);

            if (trainingType == null)
            {
                return NotFound();
            }

            return trainingType;
        }

        // POST: api/TrainingType
        [HttpPost]
        public async Task<ActionResult<TrainingType>> PostTrainingType(TrainingType trainingType)
        {
            _context.TrainingTypes.Add(trainingType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingType", new { id = trainingType.TypeID }, trainingType);
        }

        // PUT: api/TrainingType/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingType(string id, TrainingType trainingType)
        {
            if (id != trainingType.TypeID)
            {
                return BadRequest();
            }

            _context.Entry(trainingType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingTypeExists(id))
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

        // DELETE: api/TrainingType/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingType(string id)
        {
            var trainingType = await _context.TrainingTypes.FindAsync(id);
            if (trainingType == null)
            {
                return NotFound();
            }

            _context.TrainingTypes.Remove(trainingType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingTypeExists(string id)
        {
            return _context.TrainingTypes.Any(e => e.TypeID == id);
        }
    }
}
