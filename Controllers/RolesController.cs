using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Data;
using ProjectManagementAPIB.DTOs;
using ProjectManagementAPIB.image.Models;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public RolesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleWithPermissionsDTO>>> GetRoles()
        {
            // Query the roles and include PermissionRoles and their associated Permissions
            var roles = await _context.Roles
                .Include(r => r.PermissionRoles) // Include the PermissionRoles
                .ThenInclude(pr => pr.Permission) // Then include the Permissions
                .ToListAsync();

            // Map roles to RoleWithPermissionsDTO
            var rolesWithPermissions = roles.Select(role => new RoleWithPermissionsDTO
            {
                Id = role.Id,
                Name = role.Name,
                Permissions = role.PermissionRoles.Select(pr => new PermissionDTO
                {
                    Id = pr.Permission.Id,
                    Name = pr.Permission.Name,
                    Notes = pr.Permission.Notes
                }).ToList()
            }).ToList();

            return Ok(rolesWithPermissions);
        }

        // GET: api/Roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleWithPermissionsDTO>> GetRole(int id)
        {
            // Query the role by ID and include PermissionRoles and their associated Permissions
            var role = await _context.Roles
                .Include(r => r.PermissionRoles) // Include the PermissionRoles collection
                .ThenInclude(pr => pr.Permission) // Then include the associated Permissions
                .FirstOrDefaultAsync(r => r.Id == id);

            // Check if role exists
            if (role == null)
            {
                return NotFound();
            }

            // Map the role to RoleWithPermissionsDTO
            var roleWithPermissions = new RoleWithPermissionsDTO
            {
                Id = role.Id,
                Name = role.Name,
                Permissions = role.PermissionRoles.Select(pr => new PermissionDTO
                {
                    Id = pr.Permission.Id,
                    Name = pr.Permission.Name,
                    Notes = pr.Permission.Notes
                }).ToList()
            };

            // Return the role with permissions
            return Ok(roleWithPermissions);
        }


        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<RoleCreateDTO>> PostRole([FromBody] RoleCreateDTO roleDto)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(roleDto.Name))
            {
                return BadRequest("Invalid role data.");
            }

            // Create new Role entity
            var role = new Roles
            {
                Name = roleDto.Name
            };

            // Add the role to the context
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            // Return the created role
            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }


        // PUT: api/Roles/{id}
        // PUT: api/Roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, [FromBody] RoleCreateDTO roleDto)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(roleDto.Name))
            {
                return BadRequest("Invalid role data.");
            }

            var existingRole = await _context.Roles.FindAsync(id);
            if (existingRole == null)
            {
                return NotFound("Role not found.");
            }

            // Update the existing role's fields with values from the DTO
            existingRole.Name = roleDto.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // DELETE: api/Roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
