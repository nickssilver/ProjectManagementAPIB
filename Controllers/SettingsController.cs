using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public SettingsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Settings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Settings>>> GetSettings()
        {
            return await _context.Settings.ToListAsync();
        }

        // GET: api/Settings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Settings>> GetSettings(int id)
        {
            var settings = await _context.Settings.FindAsync(id);

            if (settings == null)
            {
                return NotFound();
            }

            return settings;
        }

        // POST: api/Settings
       
        [HttpPost]
        public async Task<ActionResult<Settings>> PostSettings([FromForm] SettingsRequest settingsRequest)
        {
            // Define the folder path for storing uploaded logos
            var logosFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "logos");

            // Ensure the directory exists for saving uploaded files
            if (!Directory.Exists(logosFolder))
            {
                Directory.CreateDirectory(logosFolder);
            }

            // Create a new Settings instance to store the data
            var settings = new Settings
            {
                Profile = settingsRequest.Profile,
                LegalName = settingsRequest.LegalName,
                Address = settingsRequest.Address,
                Email = settingsRequest.Email,
                TaxNo = settingsRequest.TaxNo,
                Contact = settingsRequest.Contact,
                Footer = settingsRequest.Footer,
            };

            // Handle Logo Upload
            if (settingsRequest.Logo != null && settingsRequest.Logo.Length > 0)
            {
                var originalLogoFileName = settingsRequest.Logo.FileName;

                // Create a timestamped file name
                var logoTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var logoFileName = $"{Path.GetFileNameWithoutExtension(originalLogoFileName)}_{logoTimestamp}{Path.GetExtension(originalLogoFileName)}";

                var logoFilePath = Path.Combine(logosFolder, logoFileName);

                // Save the file to the server
                using (var stream = new FileStream(logoFilePath, FileMode.Create))
                {
                    await settingsRequest.Logo.CopyToAsync(stream);
                }

                // Store relative file path in the settings model
                settings.Logo = $"/uploads/logos/{logoFileName}";
            }

            // Save settings to the database
            _context.Settings.Add(settings);
            await _context.SaveChangesAsync();

            // Return created response
            return CreatedAtAction(nameof(GetSettings), new { id = settings.ID }, settings);
        }


        // PUT: api/Settings/{id}
        // PUT: api/Settings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSettings(int id, [FromForm] SettingsRequest settingsRequest)
        {
            // Find the existing settings
            var settings = await _context.Settings.FindAsync(id);
            if (settings == null)
            {
                return NotFound();
            }

            // Update the settings fields
            settings.Profile = settingsRequest.Profile;
            settings.LegalName = settingsRequest.LegalName;
            settings.Address = settingsRequest.Address;
            settings.Email = settingsRequest.Email;
            settings.TaxNo = settingsRequest.TaxNo;
            settings.Contact = settingsRequest.Contact;
            settings.Footer = settingsRequest.Footer;

            // Define the folder path for storing uploaded logos
            var logosFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "logos");

            // Ensure the directory exists for saving uploaded files
            if (!Directory.Exists(logosFolder))
            {
                Directory.CreateDirectory(logosFolder);
            }

            // Handle Logo Upload
            if (settingsRequest.Logo != null && settingsRequest.Logo.Length > 0)
            {
                var originalLogoFileName = settingsRequest.Logo.FileName;

                // Create a timestamped file name
                var logoTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var logoFileName = $"{Path.GetFileNameWithoutExtension(originalLogoFileName)}_{logoTimestamp}{Path.GetExtension(originalLogoFileName)}";

                var logoFilePath = Path.Combine(logosFolder, logoFileName);

                // Save the file to the server
                using (var stream = new FileStream(logoFilePath, FileMode.Create))
                {
                    await settingsRequest.Logo.CopyToAsync(stream);
                }

                // Store relative file path in the settings model
                settings.Logo = $"/uploads/logos/{logoFileName}";
            }

            // Save changes to the database
            _context.Entry(settings).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Return no content response
            return NoContent();
        }


        // DELETE: api/Settings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSettings(int id)
        {
            var settings = await _context.Settings.FindAsync(id);
            if (settings == null)
            {
                return NotFound();
            }

            _context.Settings.Remove(settings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SettingsExists(int id)
        {
            return _context.Settings.Any(e => e.ID == id);
        }
    }
}
