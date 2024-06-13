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
    public class HelpersController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public HelpersController(ProjectManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Helper>>> GetHelpers()
        {
            return await _context.Helpers.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Helper>> GetHelper(string id)
        {
            var helper = await _context.Helpers.FindAsync(id);

            if (helper == null)
            {
                return NotFound();
            }

            return helper;
        }

        
        [HttpPost]
        public async Task<ActionResult<Helper>> PostHelper(Helper helper)
        {
            _context.Helpers.Add(helper);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHelper", new { id = helper.HelperID }, helper);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelper(string id, Helper helper)
        {
            if (id != helper.HelperID)
            {
                return BadRequest();
            }

            _context.Entry(helper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelperExists(id))
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

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHelper(string id)
        {
            var helper = await _context.Helpers.FindAsync(id);
            if (helper == null)
            {
                return NotFound();
            }

            _context.Helpers.Remove(helper);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HelperExists(string id)
        {
            return _context.Helpers.Any(e => e.HelperID == id);
        }
    }
}
