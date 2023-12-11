using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SGI.Data;
using SGI.Models;

namespace SGI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompraController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> Get()
        {
            var compras = await _context.Compra.ToListAsync();
            if (compras == null || !compras.Any())
            {
                return NotFound();
            }

            return compras;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> Get(int id)
        {
            if (_context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);

            if (compra == null)
            {
                return NotFound();
            }

            return compra;
        }

        [HttpPost]
        public async Task<ActionResult<Compra>> Post([FromBody] Compra compra)
        {
            if (_context.Compra == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Compras' is null.");
            }

            _context.Compra.Add(compra);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = compra.Id }, compra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Compra compra)
        {
            if (id != compra.Id)
            {
                return BadRequest();
            }

            _context.Entry(compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Compra is null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FirstOrDefaultAsync(c => c.Id == id);

            if (compra == null)
            {
                return NotFound();
            }

            _context.Compra.Remove(compra);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CompraExists(int id)
        {
            return (_context.Compra?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}

