using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGI.Data;
using SGI.Models;

namespace SGI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await _context.Categoria.ToListAsync();
            if (categorias == null || !categorias.Any())
            {
                return NotFound();
            }

            return categorias;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody] Categoria categoria)
        {
            if (_context.Categoria == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categorias' is null.");
            }

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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
            if (_context.Categoria is null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return (_context.Categoria?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}

