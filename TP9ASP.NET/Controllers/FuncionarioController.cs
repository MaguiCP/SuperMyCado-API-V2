using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMyCadoApi.Models;

namespace SuperMyCadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly SuperMyCadoContext _context;

        public FuncionarioController(SuperMyCadoContext context)
        {
            _context = context;
        }

        // GET: api/funcionario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDTO>>> GetFuncionarios()
        {
            if (_context.Funcionarios == null)
            {
                return NotFound();
            }

            return await _context.Funcionarios.Include(x => x.LojaFuncionario).Select(x => FuncionarioToDTO(x)).ToListAsync();
        }

        // GET: api/funcionario/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<FuncionarioDTO>> GetFuncionario(long id)
        {
            if (_context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.Include(x => x.LojaFuncionario).Where(x => x.FuncionarioId == id).FirstOrDefaultAsync();

            if (funcionario == null)
            {
                return NotFound();
            }
            return FuncionarioToDTO(funcionario);
        }

        // GET: api/funcionario/nomeLoja
        [HttpGet("{nomeLoja}")]
        public async Task<ActionResult<FuncionarioDTO>> GetFuncionario(string nomeLoja)
        {
            if (_context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.Include(x => x.LojaFuncionario).Where(x => x.LojaFuncionario != null && x.LojaFuncionario.NomeLoja != null && x.LojaFuncionario.NomeLoja.Equals(nomeLoja)).FirstOrDefaultAsync();

            if (funcionario == null)
            {
                return NotFound();
            }
            return FuncionarioToDTO(funcionario);
        }

        // PUT: api/funcionario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(long id, FuncionarioDTO funcionariodto)
        {
            if (id != funcionariodto.FuncionarioId)
            {
                return BadRequest();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas.Where(c => c.NomeLoja != null && c.NomeLoja.Equals(funcionariodto.NomeLojaFuncionario)).FirstOrDefaultAsync();
            if (loja == null)
            {
                return Problem("Loja not found.");
            }

            funcionario.NifFuncionario = funcionariodto.NifFuncionario;
            funcionario.NomeFuncionario = funcionariodto.NomeFuncionario;
            funcionario.LojaFuncionario = loja;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FuncionarioExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/funcionario
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostFuncionario(FuncionarioDTO funcionariodto)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'SuperMyCadoContext.Funcionarios'  is null.");
            }
            var loja = await _context.Lojas.Where(c => c.NomeLoja != null && c.NomeLoja.Equals(funcionariodto.NomeLojaFuncionario)).FirstOrDefaultAsync();
            if (loja == null)
            {
                return Problem("Loja not found.");
            }
            var funcionario = new Funcionario
            {

                NifFuncionario = funcionariodto.NifFuncionario,
                NomeFuncionario = funcionariodto.NomeFuncionario,
                LojaFuncionario = loja
            };


            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.FuncionarioId }, FuncionarioToDTO(funcionario));
        }

        // DELETE: api/funcionario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(long id)
        {
            if (_context.Funcionarios == null)
            {
                return NotFound();
            }
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(long id)
        {
            return (_context.Funcionarios?.Any(e => e.FuncionarioId == id)).GetValueOrDefault();
        }

        private static FuncionarioDTO FuncionarioToDTO(Funcionario funcionario)
        {
            FuncionarioDTO dto = new FuncionarioDTO
            {
                FuncionarioId = funcionario.FuncionarioId,
                NomeFuncionario = funcionario.NomeFuncionario,
                NomeLojaFuncionario = funcionario.LojaFuncionario?.NomeLoja,
                NifFuncionario = funcionario.NifFuncionario
            };
            return dto;
        }
    }
}