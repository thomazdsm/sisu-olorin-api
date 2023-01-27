using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sisu_olorin_api.Data;
using sisu_olorin_api.Models.Access;

namespace sisu_olorin_api.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPermissionsController : ControllerBase
    {
        private readonly DataContext _context;

        public AccessPermissionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AccessPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessPermission>>> GetAccessPermissions()
        {
            return await _context.AccessPermissions.ToListAsync();
        }

        // GET: api/AccessPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessPermission>> GetAccessPermission(int id)
        {
            var accessPermission = await _context.AccessPermissions.FindAsync(id);

            if (accessPermission == null)
            {
                return NotFound();
            }

            return accessPermission;
        }

        // PUT: api/AccessPermissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessPermission(int id, AccessPermission accessPermission)
        {
            if (id != accessPermission.Id)
            {
                return BadRequest();
            }

            _context.Entry(accessPermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessPermissionExists(id))
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

        // POST: api/AccessPermissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccessPermission>> PostAccessPermission(AccessPermission accessPermission)
        {
            _context.AccessPermissions.Add(accessPermission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessPermission", new { id = accessPermission.Id }, accessPermission);
        }

        // DELETE: api/AccessPermissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessPermission(int id)
        {
            var accessPermission = await _context.AccessPermissions.FindAsync(id);
            if (accessPermission == null)
            {
                return NotFound();
            }

            _context.AccessPermissions.Remove(accessPermission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccessPermissionExists(int id)
        {
            return _context.AccessPermissions.Any(e => e.Id == id);
        }
    }
}
