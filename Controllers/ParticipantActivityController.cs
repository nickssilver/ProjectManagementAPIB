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
        public async Task<ActionResult<ParticipantActivity>> PostParticipantProject([FromForm] ParticipantActivityRequest participantActivityRequest)
        {
            var medicalFormFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads", "medical-forms");

            // Ensure directories exist for saving uploaded files
            if (!Directory.Exists(medicalFormFolder)) Directory.CreateDirectory(medicalFormFolder);

            var participantActivity = new ParticipantActivity
            {
                AdminNumber = participantActivityRequest.AdminNumber,
                StudentName = participantActivityRequest.StudentName,
                AwardLevel = participantActivityRequest.StudentName,
                AwardCenter = participantActivityRequest.AwardCenter,
                ActivityName = participantActivityRequest.ActivityName,
                Notes = participantActivityRequest.Notes,
            };

            if (participantActivityRequest.MedicalForm != null && participantActivityRequest.MedicalForm.Length > 0)
            {
                var originalFileName = participantActivityRequest.MedicalForm.FileName;
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var medicalFormFileName = $"{Path.GetFileNameWithoutExtension(originalFileName)}_{timestamp}{Path.GetExtension(originalFileName)}";
                var medicalFormtFilePath = Path.Combine(medicalFormFolder, medicalFormFileName);

                // Save file to server
                using (var stream = new FileStream(medicalFormtFilePath, FileMode.Create))
                {
                    await participantActivityRequest.MedicalForm.CopyToAsync(stream);
                }
                participantActivity.MedicalForm = $"/Uploads/passports/{medicalFormFileName}";

            }
            _context.ParticipantActivity.Add(participantActivity);
            await _context.SaveChangesAsync();

            // Return created response
            return CreatedAtAction("GetParticipantProject", new { id = participantActivity.AdminNumber }, participantActivity);
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
