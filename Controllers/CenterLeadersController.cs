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
    public class CenterLeadersController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public CenterLeadersController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/CenterLeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CenterLeaders>>> GetCenterLeaders()
        {
            return await _context.CenterLeaders.ToListAsync();
        }

        // GET: api/CenterLeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CenterLeaders>> GetCenterLeader(string id)
        {
            var centerLeader = await _context.CenterLeaders.FindAsync(id);

            if (centerLeader == null)
            {
                return NotFound();
            }

            return centerLeader;
        }

        // POST: api/CenterLeaders
        [HttpPost]
        public async Task<ActionResult<CenterLeaders>> PostCenterLeader(CenterLeaders centerLeader)
        {
            _context.CenterLeaders.Add(centerLeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCenterLeader), new { id = centerLeader.ID }, centerLeader);
        }

        // PUT: api/CenterLeaders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCenterLeader(int id, CenterLeaders centerLeader)
        {
            if (id != centerLeader.ID)
            {
                return BadRequest();
            }

            _context.Entry(centerLeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenterLeaderExists(id))
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

        // DELETE: api/CenterLeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCenterLeader(int id)
        {
            var centerLeader = await _context.CenterLeaders.FindAsync(id);
            if (centerLeader == null)
            {
                return NotFound();
            }

            _context.CenterLeaders.Remove(centerLeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CenterLeaderExists(int id)
        {
            return _context.CenterLeaders.Any(e => e.ID == id);
        }
    }
}
