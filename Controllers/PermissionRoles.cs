using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.DTOs;
using ProjectManagementAPIB.image.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionRolesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public PermissionRolesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/PermissionRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionRoles>>> GetPermissionRoles()
        {
            return await _context.PermissionRoles
                .Include(pr => pr.Permission)
                .Include(pr => pr.Role)
                .ToListAsync();
        }

        // GET: api/PermissionRoles/{permissionId}/{roleId}
        [HttpGet("{permissionId}/{roleId}")]
        public async Task<ActionResult<PermissionRoles>> GetPermissionRole(int permissionId, int roleId)
        {
            var permissionRole = await _context.PermissionRoles
                .Where(pr => pr.PermissionId == permissionId && pr.RoleId == roleId)
                .FirstOrDefaultAsync();

            if (permissionRole == null)
            {
                return NotFound();
            }

            return permissionRole;
        }

        // POST: api/PermissionRoles
        [HttpPost]
        public async Task<ActionResult<PermissionRoles>> PostPermissionRole(PermissionRolesCreateDto permissionRolesCreateDto)
        {
            // Map the PermissionRolesCreateDto to the PermissionRoles entity
            var permissionRole = new PermissionRoles
            {
                PermissionId = permissionRolesCreateDto.PermissionId,
                RoleId = permissionRolesCreateDto.RoleId
            };

            // Add the new permission role to the context
            _context.PermissionRoles.Add(permissionRole);
            await _context.SaveChangesAsync();

            // Return the created permission role details
            return CreatedAtAction(nameof(GetPermissionRole), new { permissionId = permissionRole.PermissionId, roleId = permissionRole.RoleId }, permissionRole);
        }

        // PUT: api/PermissionRoles/{permissionId}/{roleId}
        [HttpPut("{permissionId}/{roleId}")]
        public async Task<IActionResult> PutPermissionRole(int permissionId, int roleId, PermissionRolesCreateDto permissionRolesCreateDto)
        {

            // Retrieve the existing PermissionRoles entity
            var permissionRole = await _context.PermissionRoles
                .FirstOrDefaultAsync(pr => pr.PermissionId == permissionId && pr.RoleId == roleId);

            if (permissionRole == null)
            {
                return NotFound();
            }

            // Update the PermissionRoles entity with new values from the DTO
            permissionRole.PermissionId = permissionRolesCreateDto.PermissionId;
            permissionRole.RoleId = permissionRolesCreateDto.RoleId;

            // Mark the entity as modified
            _context.Entry(permissionRole).State = EntityState.Modified;

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency issues
                if (!_context.PermissionRoles.Any(pr => pr.PermissionId == permissionId && pr.RoleId == roleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Return 204 No Content status after a successful update
            return NoContent();
        }


        // DELETE: api/PermissionRoles/{permissionId}/{roleId}
        [HttpDelete("{permissionId}/{roleId}")]
        public async Task<IActionResult> DeletePermissionRole(int permissionId, int roleId)
        {
            var permissionRole = await _context.PermissionRoles
                .Where(pr => pr.PermissionId == permissionId && pr.RoleId == roleId)
                .FirstOrDefaultAsync();

            if (permissionRole == null)
            {
                return NotFound();
            }

            _context.PermissionRoles.Remove(permissionRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionRoleExists(int permissionId, int roleId)
        {
            return _context.PermissionRoles.Any(pr => pr.PermissionId == permissionId && pr.RoleId == roleId);
        }
    }
}
