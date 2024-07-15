using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ProjectManagementAPIB.Models; // Ensure this import for the Institution model

namespace ProjectManagementAPIB.Services
{
    public class ReportService
    {
        private readonly string _jasperReportPath;

        public ReportService()
        {
            _jasperReportPath = Path.Combine(Directory.GetCurrentDirectory(), "reports", "jasperreports", "InstitutionsReport.jasper");
        }

        public async Task<string> GenerateInstitutionReportAsync(string format, List<Institution> institutions)
        {
            var parameters = new Dictionary<string, object>
            {
                { "Title", "Institution Report" }
            };

            using var reportStream = JasperReportHelper.GenerateReport(_jasperReportPath, institutions, parameters);
            var reportBytes = reportStream.ToArray();
            var reportBase64 = Convert.ToBase64String(reportBytes);

            return reportBase64;
        }
    }
}
