using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPIB.Models;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantStatusController : ControllerBase
    {
        private static List<ParticipantStatus> participantStatuses = new List<ParticipantStatus>();

        // GET: api/ParticipantStatus
        [HttpGet]
        public ActionResult<IEnumerable<ParticipantStatus>> GetParticipantStatuses()
        {
            return Ok(participantStatuses);
        }

        // GET: api/ParticipantStatus/{id}
        [HttpGet("{id}")]
        public ActionResult<ParticipantStatus> GetParticipantStatus(string id)
        {
            var participantStatus = participantStatuses.FirstOrDefault(ps => ps.StatusID == id);
            if (participantStatus == null)
            {
                return NotFound();
            }
            return Ok(participantStatus);
        }

        // POST: api/ParticipantStatus
        [HttpPost]
        public ActionResult<ParticipantStatus> PostParticipantStatus([FromBody] ParticipantStatus participantStatus)
        {
            participantStatuses.Add(participantStatus);
            return CreatedAtAction(nameof(GetParticipantStatus), new { id = participantStatus.StatusID }, participantStatus);
        }

        // PUT: api/ParticipantStatus/{id}
        [HttpPut("{id}")]
        public IActionResult PutParticipantStatus(string id, [FromBody] ParticipantStatus updatedParticipantStatus)
        {
            var participantStatus = participantStatuses.FirstOrDefault(ps => ps.StatusID == id);
            if (participantStatus == null)
            {
                return NotFound();
            }

            participantStatus.StatusName = updatedParticipantStatus.StatusName;
            participantStatus.Notes = updatedParticipantStatus.Notes;

            return NoContent();
        }

        // DELETE: api/ParticipantStatus/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipantStatus(string id)
        {
            var participantStatus = participantStatuses.FirstOrDefault(ps => ps.StatusID == id);
            if (participantStatus == null)
            {
                return NotFound();
            }

            participantStatuses.Remove(participantStatus);
            return NoContent();
        }
    }
}