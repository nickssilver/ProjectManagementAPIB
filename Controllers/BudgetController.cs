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
    public class BudgetController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public BudgetController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Budget
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budget>>> GetBudgets()
        {
            return await _context.Budgets.ToListAsync();
        }

        // GET: api/Budget/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Budget>> GetBudget(string id)
        {
            var budget = await _context.Budgets.FindAsync(id);

            if (budget == null)
            {
                return NotFound();
            }

            return budget;
        }

        // POST: api/Budget
        [HttpPost]
        public async Task<ActionResult<Budget>> PostBudget(Budget budget)
        {
            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBudget", new { id = budget.ProjectID }, budget);
        }

        // PUT: api/Budget/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudget(string id, Budget budget)
        {
            if (id != budget.ProjectID)
            {
                return BadRequest();
            }

            _context.Entry(budget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetExists(id))
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

        // DELETE: api/Budget/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(string id)
        {
            var budget = await _context.Budgets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }

            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BudgetExists(string id)
        {
            return _context.Budgets.Any(e => e.ProjectID == id);
        }
    }
}
