using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sisu_olorin_api.Data;
using sisu_olorin_api.Models.Profile;

namespace sisu_olorin_api.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfileTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProfileTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileType>>> GetProfileTypes()
        {
            return await _context.ProfileTypes.ToListAsync();
        }

        // GET: api/ProfileTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileType>> GetProfileType(int id)
        {
            var profileType = await _context.ProfileTypes.FindAsync(id);

            if (profileType == null)
            {
                return NotFound();
            }

            return profileType;
        }

        // PUT: api/ProfileTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileType(int id, ProfileType profileType)
        {
            if (id != profileType.Id)
            {
                return BadRequest();
            }

            _context.Entry(profileType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileTypeExists(id))
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

        // POST: api/ProfileTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfileType>> PostProfileType(ProfileType profileType)
        {
            _context.ProfileTypes.Add(profileType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfileType", new { id = profileType.Id }, profileType);
        }

        // DELETE: api/ProfileTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileType(int id)
        {
            var profileType = await _context.ProfileTypes.FindAsync(id);
            if (profileType == null)
            {
                return NotFound();
            }

            _context.ProfileTypes.Remove(profileType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileTypeExists(int id)
        {
            return _context.ProfileTypes.Any(e => e.Id == id);
        }
    }
}
