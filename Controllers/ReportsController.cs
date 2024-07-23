using Microsoft.AspNetCore.Mvc;
using System.IO;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.FormatProviders.Pdf; // For Flow documents (DOCX, RTF)
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx; // For Spreadsheet documents (XLSX)

namespace ProjectManagementAPIB.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        [HttpGet("exportpdf")]
        public IActionResult ExportToPdf()
        {
            var document = CreateSampleDocument();
            byte[] pdfBytes;

            using (var stream = new MemoryStream())
            {
                // Fully qualify the name to avoid ambiguity
                var pdfProvider = new Telerik.Windows.Documents.Flow.FormatProviders.Pdf.PdfFormatProvider();
                pdfProvider.Export(document, stream);
                pdfBytes = stream.ToArray();
            }

            return File(pdfBytes, "application/pdf", "report.pdf");
        }

        [HttpGet("exportexcel")]
        public IActionResult ExportToExcel()
        {
            var workbook = CreateSampleWorkbook();
            byte[] excelBytes;

            using (var stream = new MemoryStream())
            {
                var xlsxProvider = new XlsxFormatProvider();
                xlsxProvider.Export(workbook, stream);
                excelBytes = stream.ToArray();
            }

            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");
        }

        private RadFlowDocument CreateSampleDocument()
        {
            var document = new RadFlowDocument();
            var section = document.Sections.AddSection();
            var paragraph = section.Blocks.AddParagraph();
            paragraph.Inlines.AddRun("This is a sample PDF report.");
            return document;
        }

        private Workbook CreateSampleWorkbook()
        {
            var workbook = new Workbook();
            var worksheet = workbook.Worksheets.Add();
            worksheet.Cells[0, 0].SetValue("This is a sample Excel report.");
            return workbook;
        }
    }
}
