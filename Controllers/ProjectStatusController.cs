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
    public class ProjectStatusesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ProjectStatusesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/ProjectStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectStatus>>> GetProjectStatuses()
        {
            return await _context.ProjectStatuses.ToListAsync();
        }

        // GET: api/ProjectStatuses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectStatus>> GetProjectStatus(int id)
        {
            var projectStatus = await _context.ProjectStatuses.FindAsync(id);

            if (projectStatus == null)
            {
                return NotFound();
            }

            return projectStatus;
        }

        // POST: api/ProjectStatuses
        [HttpPost]
        public async Task<ActionResult<ProjectStatus>> PostProjectStatus(ProjectStatus projectStatus)
        {
            _context.ProjectStatuses.Add(projectStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectStatus", new { id = projectStatus.ProjectStatusID }, projectStatus);
        }

        // PUT: api/ProjectStatuses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectStatus(string id, ProjectStatus projectStatus)
        {
            if (id != projectStatus.ProjectStatusID)
            {
                return BadRequest();
            }

            _context.Entry(projectStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectStatusExists(id))
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

        // DELETE: api/ProjectStatuses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectStatus(int id)
        {
            var projectStatus = await _context.ProjectStatuses.FindAsync(id);
            if (projectStatus == null)
            {
                return NotFound();
            }

            _context.ProjectStatuses.Remove(projectStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectStatusExists(string id)
        {
            return _context.ProjectStatuses.Any(e => e.ProjectStatusID == id);
        }
    }
}
