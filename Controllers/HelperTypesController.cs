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
    public class HelperTypesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public HelperTypesController(ProjectManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HelperType>>> GetHelperTypes()
        {
            return await _context.HelperTypes.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<HelperType>> GetHelperType(int id)
        {
            var helperType = await _context.HelperTypes.FindAsync(id);

            if (helperType == null)
            {
                return NotFound();
            }

            return helperType;
        }

        [HttpPost]
        public async Task<ActionResult<HelperType>> PostHelperType(HelperType helperType)
        {
            _context.HelperTypes.Add(helperType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHelperType", new { id = helperType.TypeID }, helperType);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelperType(string id, HelperType helperType)
        {
            if (id != helperType.TypeID)
            {
                return BadRequest();
            }

            _context.Entry(helperType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelperTypeExists(id))
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
        public async Task<IActionResult> DeleteHelperType(string id)
        {
            var helperType = await _context.HelperTypes.FindAsync(id);
            if (helperType == null)
            {
                return NotFound();
            }

            _context.HelperTypes.Remove(helperType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HelperTypeExists(string id)
        {
            return _context.HelperTypes.Any(e => e.TypeID == id);
        }
    }
}
