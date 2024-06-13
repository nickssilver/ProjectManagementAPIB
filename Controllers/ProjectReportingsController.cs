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
    public class ProjectReportingsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ProjectReportingsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/ProjectReportings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectReporting>>> GetProjectReportings()
        {
            return await _context.ProjectReportings.ToListAsync();
        }

        // GET: api/ProjectReportings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectReporting>> GetProjectReporting(int id)
        {
            var projectReporting = await _context.ProjectReportings.FindAsync(id);

            if (projectReporting == null)
            {
                return NotFound();
            }

            return projectReporting;
        }

        // POST: api/ProjectReportings
        [HttpPost]
        public async Task<ActionResult<ProjectReporting>> PostProjectReporting(ProjectReporting projectReporting)
        {
            _context.ProjectReportings.Add(projectReporting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectReporting", new { id = projectReporting.ID }, projectReporting);
        }

        // PUT: api/ProjectReportings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectReporting(string id, ProjectReporting projectReporting)
        {
            if (id != projectReporting.ID)
            {
                return BadRequest();
            }

            _context.Entry(projectReporting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectReportingExists(id))
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

        // DELETE: api/ProjectReportings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectReporting(string id)
        {
            var projectReporting = await _context.ProjectReportings.FindAsync(id);
            if (projectReporting == null)
            {
                return NotFound();
            }

            _context.ProjectReportings.Remove(projectReporting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectReportingExists(string id)
        {
            return _context.ProjectReportings.Any(e => e.ID == id);
        }
    }
}
