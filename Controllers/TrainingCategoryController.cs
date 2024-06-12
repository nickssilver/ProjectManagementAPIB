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
    public class TrainingCategoryController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public TrainingCategoryController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/TrainingCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingCategory>>> GetTrainingCategories()
        {
            return await _context.TrainingCategories.ToListAsync();
        }

        // GET: api/TrainingCategory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingCategory>> GetTrainingCategory(int id)
        {
            var trainingCategory = await _context.TrainingCategories.FindAsync(id);

            if (trainingCategory == null)
            {
                return NotFound();
            }

            return trainingCategory;
        }

        // POST: api/TrainingCategory
        [HttpPost]
        public async Task<ActionResult<TrainingCategory>> PostTrainingCategory(TrainingCategory trainingCategory)
        {
            _context.TrainingCategories.Add(trainingCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingCategory", new { id = trainingCategory.CategoryID }, trainingCategory);
        }

        // PUT: api/TrainingCategory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingCategory(int id, TrainingCategory trainingCategory)
        {
            if (id != trainingCategory.CategoryID)
            {
                return BadRequest();
            }

            _context.Entry(trainingCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingCategoryExists(id))
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

        // DELETE: api/TrainingCategory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingCategory(int id)
        {
            var trainingCategory = await _context.TrainingCategories.FindAsync(id);
            if (trainingCategory == null)
            {
                return NotFound();
            }

            _context.TrainingCategories.Remove(trainingCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingCategoryExists(int id)
        {
            return _context.TrainingCategories.Any(e => e.CategoryID == id);
        }
    }
}
