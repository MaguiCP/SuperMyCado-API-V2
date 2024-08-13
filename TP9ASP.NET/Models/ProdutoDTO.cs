namespace SuperMyCadoApi.Models
{
    public class ProdutoDTO
    {
        public long ProdutoId { get; set; }
        public string? CodigoProduto { get; set; }
        public string? NomeProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeStock { get; set; }
        public string? SiglaGamaProduto { get; set; }
        public string? NomeLojaProduto { get; set; }
    }
}