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
    public class AwardCTypeController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public AwardCTypeController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/CentersLType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwardCType>>> GetCentersLTypes()
        {
            return await _context.AwardCTypes.ToListAsync();
        }

        // GET: api/CentersLType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AwardCType>> GetCentersLType(int id)
        {
            var centersLType = await _context.AwardCTypes.FindAsync(id);

            if (centersLType == null)
            {
                return NotFound();
            }

            return centersLType;
        }

        // POST: api/CentersLType
        [HttpPost]
        public async Task<ActionResult<AwardCType>> PostCentersLType(AwardCType centersLType)
        {
            _context.AwardCTypes.Add(centersLType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCentersLType), new { id = centersLType.ID }, centersLType);
        }

        // PUT: api/CentersLType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCentersLType(int id, AwardCType centersLType)
        {
            if (id != centersLType.ID)
            {
                return BadRequest();
            }

            _context.Entry(centersLType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentersLTypeExists(id))
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

        // DELETE: api/CentersLType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCentersLType(int id)
        {
            var centersLType = await _context.AwardCTypes.FindAsync(id);
            if (centersLType == null)
            {
                return NotFound();
            }

            _context.AwardCTypes.Remove(centersLType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CentersLTypeExists(int id)
        {
            return _context.AwardCTypes.Any(e => e.ID == id);
        }
    }
}
