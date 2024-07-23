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
    public class ParticipantProjectsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ParticipantProjectsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantProject>>> GetParticipantProjects()
        {
            return await _context.ParticipantProjects.ToListAsync();
        }

        // GET: api/ParticipantProjects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantProject>> GetParticipantProject(string id)
        {
            var participantProject = await _context.ParticipantProjects.FindAsync(id);

            if (participantProject == null)
            {
                return NotFound();
            }

            return participantProject;
        }

        // POST: api/ParticipantProjects
        [HttpPost]
        public async Task<ActionResult<ParticipantProject>> PostParticipantProject(ParticipantProject participantProject)
        {
            _context.ParticipantProjects.Add(participantProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParticipantProject), new { id = participantProject.ParticipantID }, participantProject);
        }

        // PUT: api/ParticipantProjects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantProject(string id, ParticipantProject participantProject)
        {
            if (id != participantProject.ParticipantID)
            {
                return BadRequest();
            }

            _context.Entry(participantProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantProjectExists(id))
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

        // DELETE: api/ParticipantProjects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantProject(string id)
        {
            var participantProject = await _context.ParticipantProjects.FindAsync(id);
            if (participantProject == null)
            {
                return NotFound();
            }

            _context.ParticipantProjects.Remove(participantProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantProjectExists(string id)
        {
            return _context.ParticipantProjects.Any(e => e.ParticipantID == id);
        }
    }
}
