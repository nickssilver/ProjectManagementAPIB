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
    public class GroupTypeController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public GroupTypeController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/GroupType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupType>>> GetGroupTypes()
        {
            return await _context.GroupTypes.ToListAsync();
        }

        // GET: api/GroupType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupType>> GetGroupType(string id)
        {
            var groupType = await _context.GroupTypes.FindAsync(id);

            if (groupType == null)
            {
                return NotFound();
            }

            return groupType;
        }

        // POST: api/GroupType
        [HttpPost]
        public async Task<ActionResult<GroupType>> PostGroupType(GroupType groupType)
        {
            _context.GroupTypes.Add(groupType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroupType), new { id = groupType.GroupID }, groupType);
        }

        // PUT: api/GroupType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupType(string id, GroupType groupType)
        {
            if (id != groupType.GroupID)
            {
                return BadRequest();
            }

            _context.Entry(groupType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupTypeExists(id))
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

        // DELETE: api/GroupType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupType(string id)
        {
            var groupType = await _context.GroupTypes.FindAsync(id);
            if (groupType == null)
            {
                return NotFound();
            }

            _context.GroupTypes.Remove(groupType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupTypeExists(string id)
        {
            return _context.GroupTypes.Any(e => e.GroupID == id);
        }
    }
}
