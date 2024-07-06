using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPIB.Models;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantProjectController : ControllerBase
    {
        private static List<ParticipantProject> participantProjects = new List<ParticipantProject>();

        // GET: api/ParticipantProject
        [HttpGet]
        public ActionResult<IEnumerable<ParticipantProject>> GetParticipantProjects()
        {
            return Ok(participantProjects);
        }

        // GET: api/ParticipantProject/{id}
        [HttpGet("{id}")]
        public ActionResult<ParticipantProject> GetParticipantProject(string id)
        {
            var participantProject = participantProjects.FirstOrDefault(pp => pp.ParticipantID == id);
            if (participantProject == null)
            {
                return NotFound();
            }
            return Ok(participantProject);
        }

        // POST: api/ParticipantProject
        [HttpPost]
        public ActionResult<ParticipantProject> PostParticipantProject([FromBody] ParticipantProject participantProject)
        {
            participantProjects.Add(participantProject);
            return CreatedAtAction(nameof(GetParticipantProject), new { id = participantProject.ParticipantID }, participantProject);
        }

        // PUT: api/ParticipantProject/{id}
        [HttpPut("{id}")]
        public IActionResult PutParticipantProject(string id, [FromBody] ParticipantProject updatedParticipantProject)
        {
            var participantProject = participantProjects.FirstOrDefault(pp => pp.ParticipantID == id);
            if (participantProject == null)
            {
                return NotFound();
            }

            participantProject.ParticipantName = updatedParticipantProject.ParticipantName;
            participantProject.InstitutionName = updatedParticipantProject.InstitutionName;
            participantProject.ProjectID = updatedParticipantProject.ProjectID;

            return NoContent();
        }

        // DELETE: api/ParticipantProject/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipantProject(string id)
        {
            var participantProject = participantProjects.FirstOrDefault(pp => pp.ParticipantID == id);
            if (participantProject == null)
            {
                return NotFound();
            }

            participantProjects.Remove(participantProject);
            return NoContent();
        }
    }
}