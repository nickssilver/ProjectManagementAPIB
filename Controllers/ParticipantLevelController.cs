using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPIB.Models;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantLevelController : ControllerBase
    {
        private static List<ParticipantLevel> participantLevels = new List<ParticipantLevel>();

        // GET: api/ParticipantLevel
        [HttpGet]
        public ActionResult<IEnumerable<ParticipantLevel>> GetParticipantLevels()
        {
            return Ok(participantLevels);
        }

        // GET: api/ParticipantLevel/{id}
        [HttpGet("{id}")]
        public ActionResult<ParticipantLevel> GetParticipantLevel(string id)
        {
            var participantLevel = participantLevels.FirstOrDefault(pl => pl.LevelID == id);
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
            participantLevels.Add(participantLevel);
            return CreatedAtAction(nameof(GetParticipantLevel), new { id = participantLevel.LevelID }, participantLevel);
        }

        // PUT: api/ParticipantLevel/{id}
        [HttpPut("{id}")]
        public IActionResult PutParticipantLevel(string id, [FromBody] ParticipantLevel updatedParticipantLevel)
        {
            var participantLevel = participantLevels.FirstOrDefault(pl => pl.LevelID == id);
            if (participantLevel == null)
            {
                return NotFound();
            }

            participantLevel.LevelName = updatedParticipantLevel.LevelName;
            participantLevel.Duration = updatedParticipantLevel.Duration;
            participantLevel.Notes = updatedParticipantLevel.Notes;

            return NoContent();
        }

        // DELETE: api/ParticipantLevel/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipantLevel(string id)
        {
            var participantLevel = participantLevels.FirstOrDefault(pl => pl.LevelID == id);
            if (participantLevel == null)
            {
                return NotFound();
            }

            participantLevels.Remove(participantLevel);
            return NoContent();
        }
    }
}