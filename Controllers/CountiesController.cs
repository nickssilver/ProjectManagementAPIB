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
    public class CountiesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public CountiesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Counties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<County>>> GetCounties()
        {
            return await _context.Counties.ToListAsync();
        }

        // GET: api/Counties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<County>> GetCounty(int id)
        {
            var county = await _context.Counties.FindAsync(id);

            if (county == null)
            {
                return NotFound();
            }

            return county;
        }

        // POST: api/Counties
        [HttpPost]
        public async Task<ActionResult<County>> PostCounty(County county)
        {
            _context.Counties.Add(county);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCounty), new { id = county.CountyID }, county);
        }

        // PUT: api/Counties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounty(string id, County county)
        {
            if (id != county.CountyID)
            {
                return BadRequest();
            }

            _context.Entry(county).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountyExists(id))
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

        // DELETE: api/Counties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounty(string id)
        {
            var county = await _context.Counties.FindAsync(id);
            if (county == null)
            {
                return NotFound();
            }

            _context.Counties.Remove(county);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountyExists(string id)
        {
            return _context.Counties.Any(e => e.CountyID == id);
        }
    }
}
