using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantAwardController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ParticipantAwardController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantAward
        [HttpGet]
        public ActionResult<IEnumerable<ParticipantAward>> GetParticipantAwards()
        {
            return Ok(_context.ParticipantAwards.ToList());
        }

        // GET: api/ParticipantAward/{id}
        [HttpGet("{id}")]
        public ActionResult<ParticipantAward> GetParticipantAward(string id)
        {
            var participantAward = _context.ParticipantAwards.Find(id);
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
            _context.ParticipantAwards.Add(participantAward);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetParticipantAward), new { id = participantAward.AwardID }, participantAward);
        }

        // PUT: api/ParticipantAward/{id}
        [HttpPut("{id}")]
        public IActionResult PutParticipantAward(string id, [FromBody] ParticipantAward updatedParticipantAward)
        {
            var participantAward = _context.ParticipantAwards.Find(id);
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

            _context.ParticipantAwards.Update(participantAward);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ParticipantAward/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipantAward(string id)
        {
            var participantAward = _context.ParticipantAwards.Find(id);
            if (participantAward == null)
            {
                return NotFound();
            }

            _context.ParticipantAwards.Remove(participantAward);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
