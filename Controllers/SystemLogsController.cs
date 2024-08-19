using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemLogsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public SystemLogsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/SystemLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemLogs>>> GetSysLogs()
        {
            return await _context.SysLogs.ToListAsync();
        }

        // GET: api/SystemLogs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemLogs>> GetSysLog(int id)
        {
            var systemLog = await _context.SysLogs.FindAsync(id);

            if (systemLog == null)
            {
                return NotFound();
            }

            return systemLog;
        }

        // POST: api/SystemLogs
        [HttpPost]
        public async Task<ActionResult<SystemLogs>> PostSystemLog(SystemLogs systemLog)
        {
            _context.SysLogs.Add(systemLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSysLog), new { id = systemLog.ID }, systemLog);
        }

        // PUT: api/SystemLogs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemLog(int id, SystemLogs systemLog)
        {
            if (id != systemLog.ID)
            {
                return BadRequest();
            }

            _context.Entry(systemLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemLogExists(id))
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

        // DELETE: api/SystemLogs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemLog(int id)
        {
            var systemLog = await _context.SysLogs.FindAsync(id);
            if (systemLog == null)
            {
                return NotFound();
            }

            _context.SysLogs.Remove(systemLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemLogExists(int id)
        {
            return _context.SysLogs.Any(e => e.ID == id);
        }
    }
}
