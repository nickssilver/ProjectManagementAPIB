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
    public class DonorsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public DonorsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Donors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donor>>> GetDonors()
        {
            return await _context.Donors.ToListAsync();
        }

        // GET: api/Donors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Donor>> GetDonor(string id)
        {
            var donor = await _context.Donors.FindAsync(id);

            if (donor == null)
            {
                return NotFound();
            }

            return donor;
        }

        // POST: api/Donors
        [HttpPost]
        public async Task<ActionResult<Donor>> PostDonor(Donor donor)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonor", new { id = donor.DonorID }, donor);
        }

        // PUT: api/Donors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonor(string id, Donor donor)
        {
            if (id != donor.DonorID)
            {
                return BadRequest();
            }

            _context.Entry(donor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorExists(id))
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

        // DELETE: api/Donors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonorExists(string id)
        {
            return _context.Donors.Any(e => e.DonorID == id);
        }
    }
}
