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
    public class FundingTypeController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public FundingTypeController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/FundingType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FundingType>>> GetFundingTypes()
        {
            return await _context.FundingTypes.ToListAsync();
        }

        // GET: api/FundingType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FundingType>> GetFundingType(int id)
        {
            var fundingType = await _context.FundingTypes.FindAsync(id);

            if (fundingType == null)
            {
                return NotFound();
            }

            return fundingType;
        }

        // POST: api/FundingType
        [HttpPost]
        public async Task<ActionResult<FundingType>> PostFundingType(FundingType fundingType)
        {
            _context.FundingTypes.Add(fundingType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingType", new { id = fundingType.FundingID }, fundingType);
        }

        // PUT: api/FundingType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingType(int id, FundingType fundingType)
        {
            if (id != fundingType.FundingID)
            {
                return BadRequest();
            }

            _context.Entry(fundingType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingTypeExists(id))
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

        // DELETE: api/FundingType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingType(int id)
        {
            var fundingType = await _context.FundingTypes.FindAsync(id);
            if (fundingType == null)
            {
                return NotFound();
            }

            _context.FundingTypes.Remove(fundingType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FundingTypeExists(int id)
        {
            return _context.FundingTypes.Any(e => e.FundingID == id);
        }
    }
}
