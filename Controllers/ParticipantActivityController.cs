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
    public class ParticipantActivityController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ParticipantActivityController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantActivity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantActivity>>> GetParticipantProjects()
        {
            return await _context.ParticipantActivity.ToListAsync();
        }

        // GET: api/ParticipantActivity/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantActivity>> GetParticipantProject(int id)
        {
            var participantProject = await _context.ParticipantActivity.FindAsync(id);

            if (participantProject == null)
            {
                return NotFound();
            }

            return participantProject;
        }

        // POST: api/ParticipantActivity
        [HttpPost]
        public async Task<ActionResult<ParticipantActivity>> PostParticipantProject(ParticipantActivity participantProject)
        {
            _context.ParticipantActivity.Add(participantProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParticipantProject), new { id = participantProject.ID }, participantProject);
        }

        // PUT: api/ParticipantActivity/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantProject(int id, ParticipantActivity participantProject)
        {
            if (id != participantProject.ID)
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

        // DELETE: api/ParticipantActivity/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantProject(int id)
        {
            var participantProject = await _context.ParticipantActivity.FindAsync(id);
            if (participantProject == null)
            {
                return NotFound();
            }

            _context.ParticipantActivity.Remove(participantProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantProjectExists(int id)
        {
            return _context.ParticipantActivity.Any(e => e.ID == id);
        }
    }
}
