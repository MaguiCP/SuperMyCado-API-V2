using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMyCadoApi.Models;

namespace SuperMyCadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamaController : ControllerBase
    {
        private readonly SuperMyCadoContext _context;

        public GamaController(SuperMyCadoContext context)
        {
            _context = context;
        }

        // GET: api/Gama
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gama>>> GetGamaDeProdutos()
        {
            if (_context.GamaDeProdutos == null)
            {
                return NotFound();
            }
            return await _context.GamaDeProdutos.ToListAsync();
        }

        // GET: api/Gama/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Gama>> GetGama(long id)
        {
            if (_context.GamaDeProdutos == null)
            {
                return NotFound();
            }
            var gama = await _context.GamaDeProdutos.FindAsync(id);

            if (gama == null)
            {
                return NotFound();
            }

            return gama;
        }

        // GET: api/Gama/CONG
        [HttpGet("{SiglaGama}")]
        public async Task<ActionResult<Gama>> GetGama(string SiglaGama)
        {
            if (_context.GamaDeProdutos == null)
            {
                return NotFound();
            }
            var gama = await _context.GamaDeProdutos.FirstOrDefaultAsync(g => g.SiglaGama == SiglaGama);

            if (gama == null)
            {
                return NotFound();
            }

            return gama;
        }

        // PUT: api/Gama/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGama(long id, Gama gama)
        {
            if (id != gama.GamaId)
            {
                return BadRequest();
            }

            _context.Entry(gama).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamaExists(id))
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

        // POST: api/Gama
        [HttpPost]
        public async Task<ActionResult<Gama>> PostGama(Gama gama)
        {
            if (_context.GamaDeProdutos == null)
            {
                return Problem("Entity set 'SuperMyCadoContext.GamaDeProdutos'  is null.");
            }
            _context.GamaDeProdutos.Add(gama);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGama", new { id = gama.GamaId }, gama);
        }

        // DELETE: api/Gama/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGama(long id)
        {
            if (_context.GamaDeProdutos == null)
            {
                return NotFound();
            }
            var gama = await _context.GamaDeProdutos.FindAsync(id);
            if (gama == null)
            {
                return NotFound();
            }

            _context.GamaDeProdutos.Remove(gama);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamaExists(long id)
        {
            return (_context.GamaDeProdutos?.Any(e => e.GamaId == id)).GetValueOrDefault();
        }
    }
}
