using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIExample_day30.Models;

namespace APIExample_day30.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductinfoesController : ControllerBase
    {
        private readonly ProductsDbContext _context;

        public ProductinfoesController(ProductsDbContext context)
        {
            _context = context;
        }

        // GET: api/Productinfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productinfo>>> GetProductinfos()
        {
          if (_context.Productinfos == null)
          {
              return NotFound();
          }
            return await _context.Productinfos.ToListAsync();
        }

        // GET: api/Productinfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productinfo>> GetProductinfo(int id)
        {
          if (_context.Productinfos == null)
          {
              return NotFound();
          }
            var productinfo = await _context.Productinfos.FindAsync(id);

            if (productinfo == null)
            {
                return NotFound();
            }

            return productinfo;
        }

        // PUT: api/Productinfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductinfo(int id, Productinfo productinfo)
        {
            if (id != productinfo.Pid)
            {
                return BadRequest();
            }

            _context.Entry(productinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductinfoExists(id))
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

        // POST: api/Productinfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productinfo>> PostProductinfo(Productinfo productinfo)
        {
          if (_context.Productinfos == null)
          {
              return Problem("Entity set 'ProductsDbContext.Productinfos'  is null.");
          }
            _context.Productinfos.Add(productinfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductinfoExists(productinfo.Pid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductinfo", new { id = productinfo.Pid }, productinfo);
        }

        // DELETE: api/Productinfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductinfo(int id)
        {
            if (_context.Productinfos == null)
            {
                return NotFound();
            }
            var productinfo = await _context.Productinfos.FindAsync(id);
            if (productinfo == null)
            {
                return NotFound();
            }

            _context.Productinfos.Remove(productinfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductinfoExists(int id)
        {
            return (_context.Productinfos?.Any(e => e.Pid == id)).GetValueOrDefault();
        }
    }
}
