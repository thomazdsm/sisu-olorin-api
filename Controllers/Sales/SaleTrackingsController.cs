using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sisu_olorin_api.Data;
using sisu_olorin_api.Models.Sale;

namespace sisu_olorin_api.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleTrackingsController : ControllerBase
    {
        private readonly DataContext _context;

        public SaleTrackingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SaleTrackings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleTracking>>> GetSaleTrackings()
        {
            return await _context.SaleTrackings.ToListAsync();
        }

        // GET: api/SaleTrackings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleTracking>> GetSaleTracking(int id)
        {
            var saleTracking = await _context.SaleTrackings.FindAsync(id);

            if (saleTracking == null)
            {
                return NotFound();
            }

            return saleTracking;
        }

        // PUT: api/SaleTrackings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleTracking(int id, SaleTracking saleTracking)
        {
            if (id != saleTracking.Id)
            {
                return BadRequest();
            }

            _context.Entry(saleTracking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleTrackingExists(id))
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

        // POST: api/SaleTrackings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleTracking>> PostSaleTracking(SaleTracking saleTracking)
        {
            _context.SaleTrackings.Add(saleTracking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleTracking", new { id = saleTracking.Id }, saleTracking);
        }

        // DELETE: api/SaleTrackings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleTracking(int id)
        {
            var saleTracking = await _context.SaleTrackings.FindAsync(id);
            if (saleTracking == null)
            {
                return NotFound();
            }

            _context.SaleTrackings.Remove(saleTracking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleTrackingExists(int id)
        {
            return _context.SaleTrackings.Any(e => e.Id == id);
        }
    }
}
