using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SGI.Data;

using SGI.Models;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SupplierController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> Get()
        {
            var proveedores = await _context.Proveedor.ToListAsync();
            if (proveedores == null || !proveedores.Any())
            {
                return NotFound();
            }

            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> Get(int id)
        {
            if (_context.Proveedor == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        [HttpPost]
        public async Task<ActionResult<Proveedor>> Post([FromBody] Proveedor proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest("Proveedor es nulo");
            }

            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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
            if (_context.Proveedor == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FirstOrDefaultAsync(p => p.Id == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedor.Remove(proveedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return (_context.Proveedor?.Any(p => p.Id == id)).GetValueOrDefault();
        }
    }
}

