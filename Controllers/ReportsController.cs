using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagementAPIB.Models; // Ensure this namespace is included

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly ReportService _reportService;

    public ReportsController(ReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost("generate-institution-report")]
    public async Task<IActionResult> GenerateInstitutionReport([FromBody] List<Institution> institutions, [FromQuery] string format)
    {
        try
        {
            // Call the ReportService method
            var reportBase64 = await _reportService.GenerateInstitutionReportAsync(format, institutions);

            // Convert base64 string to a byte array
            var reportBytes = Convert.FromBase64String(reportBase64);

            // Return the report as a file download
            return File(reportBytes, "application/pdf", "InstitutionReport." + format);
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
