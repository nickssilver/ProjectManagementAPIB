using Microsoft.AspNetCore.Mvc;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class ConfigController : ControllerBase
{
    [HttpPost("getconfig")]
    public IActionResult GetConfig([FromBody] Dictionary<string, string> config)
    {
        try
        {
            var content = new StringBuilder();

            foreach (var item in config)
            {
                content.AppendLine($"{item.Key}={item.Value}");
            }

            return Ok(content.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}