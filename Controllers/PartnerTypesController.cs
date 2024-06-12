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
    public class PartnerTypesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public PartnerTypesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/PartnerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnerType>>> GetPartnerTypes()
        {
            return await _context.PartnerTypes.ToListAsync();
        }

        // GET: api/PartnerTypes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerType>> GetPartnerType(int id)
        {
            var partnerType = await _context.PartnerTypes.FindAsync(id);

            if (partnerType == null)
            {
                return NotFound();
            }

            return partnerType;
        }

        // POST: api/PartnerTypes
        [HttpPost]
        public async Task<ActionResult<PartnerType>> PostPartnerType(PartnerType partnerType)
        {
            _context.PartnerTypes.Add(partnerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartnerType", new { id = partnerType.TypeID }, partnerType);
        }

        // PUT: api/PartnerTypes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartnerType(int id, PartnerType partnerType)
        {
            if (id != partnerType.TypeID)
            {
                return BadRequest();
            }

            _context.Entry(partnerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerTypeExists(id))
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

        // DELETE: api/PartnerTypes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartnerType(int id)
        {
            var partnerType = await _context.PartnerTypes.FindAsync(id);
            if (partnerType == null)
            {
                return NotFound();
            }

            _context.PartnerTypes.Remove(partnerType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartnerTypeExists(int id)
        {
            return _context.PartnerTypes.Any(e => e.TypeID == id);
        }
    }
}
