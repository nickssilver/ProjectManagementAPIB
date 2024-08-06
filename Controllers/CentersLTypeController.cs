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
    public class CentersLTypeController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public CentersLTypeController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/CentersLType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CentersLType>>> GetCentersLTypes()
        {
            return await _context.CentersLTypes.ToListAsync();
        }

        // GET: api/CentersLType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CentersLType>> GetCentersLType(string id)
        {
            var centersLType = await _context.CentersLTypes.FindAsync(id);

            if (centersLType == null)
            {
                return NotFound();
            }

            return centersLType;
        }

        // POST: api/CentersLType
        [HttpPost]
        public async Task<ActionResult<CentersLType>> PostCentersLType(CentersLType centersLType)
        {
            _context.CentersLTypes.Add(centersLType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCentersLType), new { id = centersLType.ID }, centersLType);
        }

        // PUT: api/CentersLType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCentersLType(string id, CentersLType centersLType)
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
        public async Task<IActionResult> DeleteCentersLType(string id)
        {
            var centersLType = await _context.CentersLTypes.FindAsync(id);
            if (centersLType == null)
            {
                return NotFound();
            }

            _context.CentersLTypes.Remove(centersLType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CentersLTypeExists(string id)
        {
            return _context.CentersLTypes.Any(e => e.ID == id);
        }
    }
}
