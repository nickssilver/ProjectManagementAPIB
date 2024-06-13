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
    public class TrainingController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public TrainingController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Training
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> GetTrainings()
        {
            return await _context.Trainings.ToListAsync();
        }

        // GET: api/Training/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
            var training = await _context.Trainings.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return training;
        }

        // POST: api/Training
        [HttpPost]
        public async Task<ActionResult<Training>> PostTraining(Training training)
        {
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraining", new { id = training.TrainingID }, training);
        }

        // PUT: api/Training/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining(string id, Training training)
        {
            if (id != training.TrainingID)
            {
                return BadRequest();
            }

            _context.Entry(training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(id))
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

        // DELETE: api/Training/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(string id)
        {
            var training = await _context.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingExists(string id)
        {
            return _context.Trainings.Any(e => e.TrainingID == id);
        }
    }
}
