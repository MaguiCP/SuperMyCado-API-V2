using Microsoft.EntityFrameworkCore;

namespace SuperMyCadoApi.Models
{
    public class SuperMyCadoContext : DbContext
    {
        public SuperMyCadoContext(DbContextOptions<SuperMyCadoContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public DbSet<Gama> GamaDeProdutos { get; set; } = null!;
        public DbSet<Loja> Lojas { get; set; } = null!;
        public DbSet<Produto> Produtos { get; set; } = null!;
    }
}