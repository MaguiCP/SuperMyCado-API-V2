using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMyCadoApi.Models;

namespace SuperMyCadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly SuperMyCadoContext _context;

        public ProdutoController(SuperMyCadoContext context)
        {
            _context = context;
        }

        // GET: api/produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutos()
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }

            return await _context.Produtos.Include(x => x.LojaProduto).Include(s => s.GamaProduto).Select(x => ProdutoToDTO(x)).ToListAsync();
        }

        // GET: api/produto/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> GetProduto(long id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.Include(x => x.LojaProduto).Include(s => s.GamaProduto).Where(x => x.ProdutoId == id).FirstOrDefaultAsync();

            if (produto == null)
            {
                return NotFound();
            }
            return ProdutoToDTO(produto);
        }

        // GET: api/produto/cod
        [HttpGet("{cod}")]
        public async Task<ActionResult<ProdutoDTO>> GetProduto(string cod)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.Include(x => x.LojaProduto).Include(s => s.GamaProduto).Where(x => x.CodigoProduto == cod).FirstOrDefaultAsync();

            if (produto == null)
            {
                return NotFound();
            }
            return ProdutoToDTO(produto);
        }

        // PUT: api/produto/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutProduto(long id, ProdutoDTO produtodto)
        {
            if (id != produtodto.ProdutoId)
            {
                return BadRequest();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas.Where(c => c.NomeLoja != null && c.NomeLoja.Equals(produtodto.NomeLojaProduto)).FirstOrDefaultAsync();
            if (loja == null)
            {
                return Problem("Loja not found.");
            }
            var gama = await _context.GamaDeProdutos.Where(c => c.SiglaGama != null && c.SiglaGama.Equals(produtodto.SiglaGamaProduto)).FirstOrDefaultAsync();
            if (gama == null)
            {
                return Problem("Gama not found.");
            }

            produto.CodigoProduto = produtodto.CodigoProduto;
            produto.NomeProduto = produtodto.NomeProduto;
            produto.PrecoUnitario = produtodto.PrecoUnitario;
            produto.QuantidadeStock = produtodto.QuantidadeStock;
            produto.LojaProduto = loja;
            produto.GamaProduto = gama;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ProdutoExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }


        // POST: api/produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(ProdutoDTO produtodto)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'SuperMyCadoContext.Produtos' is null.");
            }
            var loja = await _context.Lojas.Where(c => c.NomeLoja != null && c.NomeLoja.Equals(produtodto.NomeLojaProduto)).FirstOrDefaultAsync();

            if (loja == null)
            {
                return Problem("Loja not found.");
            }
            var gama = await _context.GamaDeProdutos.Where(c => c.SiglaGama != null && c.SiglaGama.Equals(produtodto.SiglaGamaProduto)).FirstOrDefaultAsync();
            if (gama == null)
            {
                return Problem("Gama not found.");
            }
            var produto = new Produto
            {
                CodigoProduto = produtodto.CodigoProduto,
                NomeProduto = produtodto.NomeProduto,
                PrecoUnitario = produtodto.PrecoUnitario,
                QuantidadeStock = produtodto.QuantidadeStock,
                LojaProduto = loja,
                GamaProduto = gama
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.ProdutoId }, ProdutoToDTO(produto));
        }

        // DELETE: api/produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(long id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(long id)
        {
            return (_context.Produtos?.Any(e => e.ProdutoId == id)).GetValueOrDefault();
        }

        private bool ProdutoExists(string codProduto)
        {
            return _context.Produtos.Any(p => p.CodigoProduto == codProduto);
        }

        private static ProdutoDTO ProdutoToDTO(Produto produto)
        {
            ProdutoDTO dto = new ProdutoDTO
            {
                ProdutoId = produto.ProdutoId,
                CodigoProduto = produto.CodigoProduto,
                NomeProduto = produto.NomeProduto,
                PrecoUnitario = produto.PrecoUnitario,
                QuantidadeStock = produto.QuantidadeStock,
                NomeLojaProduto = produto.LojaProduto?.NomeLoja,
                SiglaGamaProduto = produto.GamaProduto?.SiglaGama
            };
            return dto;
        }
    }
}