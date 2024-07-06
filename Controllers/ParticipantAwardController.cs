using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPIB.Models;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantAwardController : ControllerBase
    {
        private static List<ParticipantAward> participantAwards = new List<ParticipantAward>();

        // GET: api/ParticipantAward
        [HttpGet]
        public ActionResult<IEnumerable<ParticipantAward>> GetParticipantAwards()
        {
            return Ok(participantAwards);
        }

        // GET: api/ParticipantAward/{id}
        [HttpGet("{id}")]
        public ActionResult<ParticipantAward> GetParticipantAward(string id)
        {
            var participantAward = participantAwards.FirstOrDefault(pa => pa.AwardID == id);
            if (participantAward == null)
            {
                return NotFound();
            }
            return Ok(participantAward);
        }

        // POST: api/ParticipantAward
        [HttpPost]
        public ActionResult<ParticipantAward> PostParticipantAward([FromBody] ParticipantAward participantAward)
        {
            participantAwards.Add(participantAward);
            return CreatedAtAction(nameof(GetParticipantAward), new { id = participantAward.AwardID }, participantAward);
        }

        // PUT: api/ParticipantAward/{id}
        [HttpPut("{id}")]
        public IActionResult PutParticipantAward(string id, [FromBody] ParticipantAward updatedParticipantAward)
        {
            var participantAward = participantAwards.FirstOrDefault(pa => pa.AwardID == id);
            if (participantAward == null)
            {
                return NotFound();
            }

            participantAward.AdminNo = updatedParticipantAward.AdminNo;
            participantAward.StudentName = updatedParticipantAward.StudentName;
            participantAward.InstitutionName = updatedParticipantAward.InstitutionName;
            participantAward.LevelName = updatedParticipantAward.LevelName;
            participantAward.StartDate = updatedParticipantAward.StartDate;
            participantAward.EndDate = updatedParticipantAward.EndDate;
            participantAward.Status = updatedParticipantAward.Status;
            participantAward.Notes = updatedParticipantAward.Notes;

            return NoContent();
        }

        // DELETE: api/ParticipantAward/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipantAward(string id)
        {
            var participantAward = participantAwards.FirstOrDefault(pa => pa.AwardID == id);
            if (participantAward == null)
            {
                return NotFound();
            }

            participantAwards.Remove(participantAward);
            return NoContent();
        }
    }
}