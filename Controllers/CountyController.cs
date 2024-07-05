using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public CountyController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/County
        [HttpGet]
        public async Task<ActionResult<IEnumerable<County>>> GetCounties()
        {
            return await _context.Counties.ToListAsync();
        }

        // GET: api/County/5
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

        // GET: api/County/5/SubCounties
        [HttpGet("{id}/SubCounties")]
        public async Task<IActionResult> GetSubCountiesByCountyId(int id)
        {
            var county = await _context.Counties
                .Include(c => c.SubCounties)
                .FirstOrDefaultAsync(c => c.CountyID == id);

            if (county == null)
            {
                return NotFound();
            }

            // Use custom JSON options for this specific response
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var result = new ContentResult
            {
                Content = JsonSerializer.Serialize(county.SubCounties, options),
                ContentType = "application/json",
                StatusCode = 200
            };

            return result;
        }

        // POST: api/County
        [HttpPost]
        public async Task<ActionResult<County>> PostCounty(County county)
        {
            _context.Counties.Add(county);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCounty", new { id = county.CountyID }, county);
        }

        // PUT: api/County/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounty(int id, County county)
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

        // DELETE: api/County/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounty(int id)
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

        private bool CountyExists(int id)
        {
            return _context.Counties.Any(e => e.CountyID == id);
        }
    }
}