﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public InstitutionsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Institutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutions()
        {
            return await _context.Institutions.ToListAsync();
        }

        // GET: api/Institutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institution>> GetInstitution(string id)
        {
            var institution = await _context.Institutions.FindAsync(id);

            if (institution == null)
            {
                return NotFound();
            }

            return institution;
        }

        // POST: api/Institutions
        [HttpPost]
        public async Task<ActionResult<Institution>> PostInstitution(Institution institution)
        {
            _context.Institutions.Add(institution);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstitution), new { id = institution.InstitutionID }, institution);
        }

        // PUT: api/Institutions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitution(string id, Institution institution)
        {
            if (id != institution.InstitutionID)
            {
                return BadRequest();
            }

            _context.Entry(institution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionExists(id))
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

        // DELETE: api/Institutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution(string id)
        {
            var institution = await _context.Institutions.FindAsync(id);
            if (institution == null)
            {
                return NotFound();
            }

            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutionExists(string id)
        {
            return _context.Institutions.Any(e => e.InstitutionID == id);
        }
    }
}
