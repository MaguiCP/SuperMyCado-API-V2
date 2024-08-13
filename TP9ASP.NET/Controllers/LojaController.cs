using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMyCadoApi.Models;

namespace SuperMyCadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojaController : ControllerBase
    {
        private readonly SuperMyCadoContext _context;

        public LojaController(SuperMyCadoContext context)
        {
            _context = context;
        }

        // GET: api/Loja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loja>>> GetLojas()
        {
            if (_context.Lojas == null)
            {
                return NotFound();
            }
            return await _context.Lojas.ToListAsync();
        }

        // GET: api/Loja/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Loja>> GetLoja(long id)
        {
            if (_context.Lojas == null)
            {
                return NotFound();
            }
            var loja = await _context.Lojas.FindAsync(id);

            if (loja == null)
            {
                return NotFound();
            }

            return loja;
        }
        // GET: api/Loja/loc
        [HttpGet("{loc}")]
        public async Task<ActionResult<Loja>> GetLoja(String loc)
        {
            if (_context.Lojas == null)
            {
                return NotFound();
            }
            var loja = await _context.Lojas.FirstOrDefaultAsync(l => l.LocalizacaoLoja == loc);

            if (loja == null)
            {
                return NotFound();
            }

            return loja;
        }

        // PUT: api/Loja/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoja(long id, Loja loja)
        {
            if (id != loja.LojaId)
            {
                return BadRequest();
            }

            _context.Entry(loja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LojaExists(id))
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

        // POST: api/Loja
        [HttpPost]
        public async Task<ActionResult<Loja>> PostLoja(Loja loja)
        {
            if (_context.Lojas == null)
            {
                return Problem("Entity set 'SuperContext.Lojas'  is null.");
            }
            _context.Lojas.Add(loja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoja", new { id = loja.LojaId }, loja);
        }

        // DELETE: api/Loja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoja(long id)
        {
            if (_context.Lojas == null)
            {
                return NotFound();
            }
            var loja = await _context.Lojas.FindAsync(id);
            if (loja == null)
            {
                return NotFound();
            }

            _context.Lojas.Remove(loja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LojaExists(long id)
        {
            return (_context.Lojas?.Any(e => e.LojaId == id)).GetValueOrDefault();
        }
    }
}