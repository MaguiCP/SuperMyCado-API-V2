namespace SuperMyCadoApi.Models
{
    public class Produto
    {
        public long ProdutoId { get; set; }
        public string? CodigoProduto { get; set; }
        public string? NomeProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeStock { get; set; }
        public Gama? GamaProduto { get; set; }
        public Loja? LojaProduto { get; set; }
    }
}