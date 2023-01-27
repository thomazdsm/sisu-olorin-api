using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sisu_olorin_api.Data;
using sisu_olorin_api.Models.Product;

namespace sisu_olorin_api.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductStatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProductStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductStatus>>> GetProductStatus()
        {
            return await _context.ProductStatus.ToListAsync();
        }

        // GET: api/ProductStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductStatus>> GetProductStatus(int id)
        {
            var productStatus = await _context.ProductStatus.FindAsync(id);

            if (productStatus == null)
            {
                return NotFound();
            }

            return productStatus;
        }

        // PUT: api/ProductStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductStatus(int id, ProductStatus productStatus)
        {
            if (id != productStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(productStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductStatusExists(id))
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

        // POST: api/ProductStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductStatus>> PostProductStatus(ProductStatus productStatus)
        {
            _context.ProductStatus.Add(productStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductStatus", new { id = productStatus.Id }, productStatus);
        }

        // DELETE: api/ProductStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductStatus(int id)
        {
            var productStatus = await _context.ProductStatus.FindAsync(id);
            if (productStatus == null)
            {
                return NotFound();
            }

            _context.ProductStatus.Remove(productStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductStatusExists(int id)
        {
            return _context.ProductStatus.Any(e => e.Id == id);
        }
    }
}
