using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SGI.Data;
using SGI.Models;

namespace SGI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VentaController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> Get()
        {
            var ventas = await _context.Venta.ToListAsync();
            if (ventas == null || !ventas.Any())
            {
                return NotFound();
            }

            return ventas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> Get(int id)
        {
            if (_context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> Post([FromBody] Venta venta)
        {
            if (_context.Venta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ventas' is null.");
            }

            _context.Venta.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = venta.Id }, venta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Venta venta)
        {
            if (id != venta.Id)
            {
                return BadRequest();
            }

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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
            if (_context.Venta is null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null)
            {
                return NotFound();
            }

            _context.Venta.Remove(venta);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return (_context.Venta?.Any(v => v.Id == id)).GetValueOrDefault();
        }
    }
}

