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
    public class TestimonialsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public TestimonialsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Testimonials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonial>>> GetTestimonials()
        {
            return await _context.Testimonials.ToListAsync();
        }

        // GET: api/Testimonials/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonial>> GetTestimonial(string id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);

            if (testimonial == null)
            {
                return NotFound();
            }

            return testimonial;
        }

        // POST: api/Testimonials
        [HttpPost]
        public async Task<ActionResult<Testimonial>> PostTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestimonial", new { id = testimonial.UserID }, testimonial);
        }

        // PUT: api/Testimonials/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestimonial(string id, Testimonial testimonial)
        {
            if (id != testimonial.UserID)
            {
                return BadRequest();
            }

            _context.Entry(testimonial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestimonialExists(id))
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

        // DELETE: api/Testimonials/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }

            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestimonialExists(string id)
        {
            return _context.Testimonials.Any(e => e.UserID == id);
        }
    }
}
