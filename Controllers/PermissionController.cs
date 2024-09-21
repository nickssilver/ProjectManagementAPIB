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
    public class PermissionController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public PermissionController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/Permissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionWithRolesDTO>>> GetPermissions()
        {
            // Retrieve all permissions and include related PermissionRoles and Roles
            var permissions = await _context.Permissions
                .Include(p => p.PermissionRoles)  // Include the PermissionRoles
                .ThenInclude(pr => pr.Role)       // Then include the related Roles
                .ToListAsync();

            // Map the permissions to PermissionWithRolesDTO
            var permissionsWithRoles = permissions.Select(p => new PermissionWithRolesDTO
            {
                Id = p.Id,
                Name = p.Name,
                Notes = p.Notes,
                Roles = p.PermissionRoles.Select(pr => new Roles
                {
                    Id = pr.Role.Id,
                    Name = pr.Role.Name
                }).ToList()
            }).ToList();

            return Ok(permissionsWithRoles);
        }


        // GET: api/Permissions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionWithRolesDTO>> GetPermission(int id)
        {
            // Retrieve the permission by id and include related PermissionRoles and Roles
            var permission = await _context.Permissions
                .Include(p => p.PermissionRoles)  // Include the PermissionRoles
                .ThenInclude(pr => pr.Role)       // Then include the related Roles
                .FirstOrDefaultAsync(p => p.Id == id);

            if (permission == null)
            {
                return NotFound();
            }

            // Map the permission to PermissionWithRolesDTO
            var permissionWithRoles = new PermissionWithRolesDTO
            {
                Id = permission.Id,
                Name = permission.Name,
                Notes = permission.Notes,
                Roles = permission.PermissionRoles.Select(pr => new Roles
                {
                    Id = pr.Role.Id,
                    Name = pr.Role.Name
                }).ToList()
            };

            return Ok(permissionWithRoles);
        }


        // POST: api/Permissions
        [HttpPost]
        public async Task<ActionResult<PermissionDTO>> PostPermission(PermissionCreateDTO permissionCreateDto)
        {
            // Map the PermissionCreateDTO to the Permissions entity
            var permission = new Permissions
            {
                Id = permissionCreateDto.Id,
                Name = permissionCreateDto.Name,
                Notes = permissionCreateDto.Notes
            };

            // Add the new permission to the context
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();

            // Map the created entity to the PermissionDTO to return it
            var permissionDto = new PermissionDTO
            {
                Id = permission.Id,
                Name = permission.Name,
                Notes = permission.Notes
            };

            return CreatedAtAction(nameof(GetPermission), new { id = permission.Id }, permissionDto);
        }


        // PUT: api/Permissions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermission(int id, PermissionCreateDTO permissionCreateDto)
        {
            // Retrieve the existing permission entity
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound($"Permission with ID {id} not found.");
            }

            // Map the PermissionCreateDTO to the existing Permissions entity
            permission.Name = permissionCreateDto.Name;
            permission.Notes = permissionCreateDto.Notes;

            // Mark the entity as modified
            _context.Entry(permission).State = EntityState.Modified;

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionExists(id))
                {
                    return NotFound($"Permission with ID {id} does not exist.");
                }
                else
                {
                    throw; // Re-throw the exception if it's a different issue
                }
            }

            // Return the updated PermissionDTO, similar to how you handle in the POST action
            var permissionDto = new PermissionDTO
            {
                Id = permission.Id,
                Name = permission.Name,
                Notes = permission.Notes
            };

            // Return the updated permission data (optionally you can return NoContent if no response body is needed)
            return Ok(permissionDto);
        }

        // DELETE: api/Permissions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionExists(int id)
        {
            return _context.Permissions.Any(e => e.Id == id);
        }
    }
}
