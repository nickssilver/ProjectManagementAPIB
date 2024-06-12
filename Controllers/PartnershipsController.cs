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
    public class PartnershipsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public PartnershipsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Partnerships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partnership>>> GetPartnerships()
        {
            return await _context.Partnerships.ToListAsync();
        }

        // GET: api/Partnerships/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Partnership>> GetPartnership(int id)
        {
            var partnership = await _context.Partnerships.FindAsync(id);

            if (partnership == null)
            {
                return NotFound();
            }

            return partnership;
        }

        // POST: api/Partnerships
        [HttpPost]
        public async Task<ActionResult<Partnership>> PostPartnership(Partnership partnership)
        {
            _context.Partnerships.Add(partnership);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartnership", new { id = partnership.PartnerID }, partnership);
        }

        // PUT: api/Partnerships/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartnership(int id, Partnership partnership)
        {
            if (id != partnership.PartnerID)
            {
                return BadRequest();
            }

            _context.Entry(partnership).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnershipExists(id))
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

        // DELETE: api/Partnerships/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartnership(int id)
        {
            var partnership = await _context.Partnerships.FindAsync(id);
            if (partnership == null)
            {
                return NotFound();
            }

            _context.Partnerships.Remove(partnership);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartnershipExists(int id)
        {
            return _context.Partnerships.Any(e => e.PartnerID == id);
        }
    }
}
