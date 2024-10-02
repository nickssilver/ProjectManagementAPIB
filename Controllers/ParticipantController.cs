using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.DTOs;
using ProjectManagementAPIB.Models;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ParticipantsController : ControllerBase
{
    private readonly ProjectManagementContext _context;
    private readonly string passportFolder = "C:/passports";
    private readonly string docsFolder = "C:/docs";

    public ParticipantsController(ProjectManagementContext context)
    {
        _context = context;
    }

    // GET: api/Participants
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
    {
        return await _context.Participants.ToListAsync();
    }

    // GET: api/Participants/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Participant>> GetParticipant(string id)
    {
        var participant = await _context.Participants.FindAsync(id);

        if (participant == null)
        {
            return NotFound();
        }

        return participant;
    }

    // POST: api/Participants

    [HttpPost]
    public async Task<ActionResult<Participant>> PostParticipant([FromForm] ParticipantRequestDTO participantRequest)
    {
        
        // Define the folder paths for storing passport photos and documents
        var passportFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "passports");
        var docsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "docs");

        // Ensure directories exist for saving uploaded files
        if (!Directory.Exists(passportFolder)) Directory.CreateDirectory(passportFolder);
        if (!Directory.Exists(docsFolder)) Directory.CreateDirectory(docsFolder);

        // Create new participant instance to store the data
        var participant = new Participant
        {
            AdminNumber = participantRequest.AdminNumber,
            Name = participantRequest.Name,
            DOB = participantRequest.DOB,
            Gender = participantRequest.Gender,
            Age = participantRequest.Age,
            Religion = participantRequest.Religion,
            Ethnicity = participantRequest.Ethnicity,
            Nationality = participantRequest.Nationality,
            PhoneNumber = participantRequest.PhoneNumber,
            Email = participantRequest.Email,
            InstitutionName = participantRequest.InstitutionName,
            Region = participantRequest.Region,
            County = participantRequest.County,
            SubCounty = participantRequest.SubCounty,
            GuardianName = participantRequest.GuardianName,
            GuardianContact = participantRequest.GuardianContact,
            EmergencyCName = participantRequest.EmergencyCName,
            EmergencyCNumber = participantRequest.EmergencyCNumber,
            PaymentStatus = participantRequest.PaymentStatus,
            Marginalised = participantRequest.Marginalised,
            AtRisk = participantRequest.AtRisk,
            Notes = participantRequest.Notes,
            PassportPhoto = "",
            DocUpload = ""
        };



        // Handle Passport Photo Upload
        if (participantRequest.PassportPhoto != null && participantRequest.PassportPhoto.Length > 0)
        {
            var passportFileName = Path.GetFileName(participantRequest.PassportPhoto.FileName);
            var passportFilePath = Path.Combine(passportFolder, passportFileName);

            // Save file to server
            using (var stream = new FileStream(passportFilePath, FileMode.Create))
            {
                await participantRequest.PassportPhoto.CopyToAsync(stream);
            }

            // Store relative file path in the participant model
            participant.PassportPhoto = $"/uploads/passports/{passportFileName}";
        }

        // Handle Document Upload
        if (participantRequest.Doc != null && participantRequest.Doc.Length > 0)
        {
            var docFileName = Path.GetFileName(participantRequest.Doc.FileName);
            var docFilePath = Path.Combine(docsFolder, docFileName);

            // Save file to server
            using (var stream = new FileStream(docFilePath, FileMode.Create))
            {
                await participantRequest.Doc.CopyToAsync(stream);
            }

            // Store relative file path in the participant model
            participant.DocUpload = $"/uploads/docs/{docFileName}";
        }

        // Save participant to the database
        _context.Participants.Add(participant);
        await _context.SaveChangesAsync();

        // Return created response
        return CreatedAtAction("GetParticipant", new { id = participant.AdminNumber }, participant);
    }

    // PUT: api/Participants/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutParticipant(string id, [FromForm] ParticipantRequest participantRequest)
    {
        if (id != participantRequest.Participant.AdminNumber)
        {
            return BadRequest("Admin number mismatch.");
        }

        var participant = await _context.Participants.FindAsync(id);
        if (participant == null)
        {
            return NotFound();
        }

        // Update participant fields from DTO
        participant.Name = participantRequest.Participant.Name;
        participant.DOB = participantRequest.Participant.DOB;
        participant.Gender = participantRequest.Participant.Gender;
        participant.Age = participantRequest.Participant.Age;
        participant.Religion = participantRequest.Participant.Religion;
        participant.Ethnicity = participantRequest.Participant.Ethnicity;
        participant.Nationality = participantRequest.Participant.Nationality;
        participant.PhoneNumber = participantRequest.Participant.PhoneNumber;
        participant.Email = participantRequest.Participant.Email;
        participant.InstitutionName = participantRequest.Participant.InstitutionName;
        participant.Region = participantRequest.Participant.Region;
        participant.County = participantRequest.Participant.County;
        participant.SubCounty = participantRequest.Participant.SubCounty;
        participant.GuardianName = participantRequest.Participant.GuardianName;
        participant.GuardianContact = participantRequest.Participant.GuardianContact;
        participant.EmergencyCName = participantRequest.Participant.EmergencyCName;
        participant.EmergencyCNumber = participantRequest.Participant.EmergencyCNumber;
        participant.EmergencyCRelation = participantRequest.Participant.EmergencyCRelation;
        participant.PaymentStatus = participantRequest.Participant.PaymentStatus;
        participant.Marginalised = participantRequest.Participant.Marginalised;
        participant.AtRisk = participantRequest.Participant.AtRisk;
        participant.Notes = participantRequest.Participant.Notes;

        // Handle Passport Photo Upload
        if (participantRequest.PassportPhoto != null)
        {
            var passportFilePath = Path.Combine(passportFolder, participantRequest.PassportPhoto.FileName);
            using (var stream = new FileStream(passportFilePath, FileMode.Create))
            {
                await participantRequest.PassportPhoto.CopyToAsync(stream);
            }
            participant.PassportPhoto = $"/passports/{participantRequest.PassportPhoto.FileName}";
        }

        // Handle Document Upload
        if (participantRequest.Doc != null)
        {
            var docFilePath = Path.Combine(docsFolder, participantRequest.Doc.FileName);
            using (var stream = new FileStream(docFilePath, FileMode.Create))
            {
                await participantRequest.Doc.CopyToAsync(stream);
            }
            participant.DocUpload = $"/docs/{participantRequest.Doc.FileName}";
        }

        _context.Entry(participant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParticipantExists(id))
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

    // DELETE: api/Participants/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParticipant(string id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant == null)
        {
            return NotFound();
        }

        _context.Participants.Remove(participant);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ParticipantExists(string id)
    {
        return _context.Participants.Any(e => e.AdminNumber == id);
    }
}
