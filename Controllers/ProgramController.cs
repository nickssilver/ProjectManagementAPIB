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
    public class ProgramsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ProgramsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Programs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programm>>> GetPrograms()
        {
            return await _context.Programs.ToListAsync();
        }

        // GET: api/Programs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Programm>> GetProgram(string id)
        {
            var program = await _context.Programs.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            return program;
        }

        // POST: api/Programs
        [HttpPost]
        public async Task<ActionResult<Programm>> PostProgram(Programm program)
        {
            _context.Programs.Add(program);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProgram), new { id = program.ProgramID }, program);
        }

        // PUT: api/Programs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgram(string id, Programm program)
        {
            if (id != program.ProgramID)
            {
                return BadRequest();
            }

            _context.Entry(program).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
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

        // DELETE: api/Programs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(string id)
        {
            var program = await _context.Programs.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            _context.Programs.Remove(program);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramExists(string id)
        {
            return _context.Programs.Any(e => e.ProgramID == id);
        }
    }
}
