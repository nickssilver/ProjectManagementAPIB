using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantLevelController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ParticipantLevelController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantLevel
        [HttpGet]
        public ActionResult<IEnumerable<ParticipantLevel>> GetParticipantLevels()
        {
            return Ok(_context.ParticipantLevels.ToList());
        }

        // GET: api/ParticipantLevel/{id}
        [HttpGet("{id}")]
        public ActionResult<ParticipantLevel> GetParticipantLevel(string id)
        {
            var participantLevel = _context.ParticipantLevels.Find(id);
            if (participantLevel == null)
            {
                return NotFound();
            }
            return Ok(participantLevel);
        }

        // POST: api/ParticipantLevel
        [HttpPost]
        public ActionResult<ParticipantLevel> PostParticipantLevel([FromBody] ParticipantLevel participantLevel)
        {
            _context.ParticipantLevels.Add(participantLevel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetParticipantLevel), new { id = participantLevel.LevelID }, participantLevel);
        }

        // PUT: api/ParticipantLevel/{id}
        [HttpPut("{id}")]
        public IActionResult PutParticipantLevel(string id, [FromBody] ParticipantLevel updatedParticipantLevel)
        {
            var participantLevel = _context.ParticipantLevels.Find(id);
            if (participantLevel == null)
            {
                return NotFound();
            }

            participantLevel.LevelName = updatedParticipantLevel.LevelName;
            participantLevel.Duration = updatedParticipantLevel.Duration;
            participantLevel.Notes = updatedParticipantLevel.Notes;

            _context.ParticipantLevels.Update(participantLevel);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ParticipantLevel/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipantLevel(string id)
        {
            var participantLevel = _context.ParticipantLevels.Find(id);
            if (participantLevel == null)
            {
                return NotFound();
            }

            _context.ParticipantLevels.Remove(participantLevel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
