using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectApi.Data;
using SGI.Data;
using SGI.Models;

namespace SGI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComprasController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compras>>> Get()
        {
            var compras = await _context.Compras.ToListAsync();
            if (compras == null || !compras.Any())
            {
                return NotFound();
            }

            return compras;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compras>> Get(int id)
        {
            if (_context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);

            if (compra == null)
            {
                return NotFound();
            }

            return compra;
        }

        [HttpPost]
        public async Task<ActionResult<Compras>> Post([FromBody] Compras compra)
        {
            if (_context.Compras == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Compras' is null.");
            }

            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = compra.Id }, compra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Compras compra)
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
            if (_context.Compras is null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FirstOrDefaultAsync(c => c.Id == id);

            if (compra == null)
            {
                return NotFound();
            }

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CompraExists(int id)
        {
            return (_context.Compras?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}

