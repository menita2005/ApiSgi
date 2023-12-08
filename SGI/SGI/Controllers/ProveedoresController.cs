using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SGI.Data;

using SGI.Models;

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedores>>> Get()
        {
            var proveedores = await _context.Proveedores.ToListAsync();
            if (proveedores == null || !proveedores.Any())
            {
                return NotFound();
            }

            return proveedores;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedores>> Get(int id)
        {
            if (_context.Proveedores == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        [HttpPost]
        public async Task<ActionResult<Proveedores>> Post([FromBody] Proveedores proveedor)
        {
            if (_context.Proveedores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Proveedores' is null.");
            }

            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Proveedores proveedor)
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
            if (_context.Proveedores is null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(p => p.Id == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return (_context.Proveedores?.Any(p => p.Id == id)).GetValueOrDefault();
        }
    }
}

