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
    public class SaleStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public SaleStatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SaleStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleStatus>>> GetSaleStatus()
        {
            return await _context.SaleStatus.ToListAsync();
        }

        // GET: api/SaleStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleStatus>> GetSaleStatus(int id)
        {
            var saleStatus = await _context.SaleStatus.FindAsync(id);

            if (saleStatus == null)
            {
                return NotFound();
            }

            return saleStatus;
        }

        // PUT: api/SaleStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleStatus(int id, SaleStatus saleStatus)
        {
            if (id != saleStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(saleStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleStatusExists(id))
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

        // POST: api/SaleStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleStatus>> PostSaleStatus(SaleStatus saleStatus)
        {
            _context.SaleStatus.Add(saleStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleStatus", new { id = saleStatus.Id }, saleStatus);
        }

        // DELETE: api/SaleStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleStatus(int id)
        {
            var saleStatus = await _context.SaleStatus.FindAsync(id);
            if (saleStatus == null)
            {
                return NotFound();
            }

            _context.SaleStatus.Remove(saleStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleStatusExists(int id)
        {
            return _context.SaleStatus.Any(e => e.Id == id);
        }
    }
}
