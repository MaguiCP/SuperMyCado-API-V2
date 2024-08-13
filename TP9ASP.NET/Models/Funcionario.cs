namespace SuperMyCadoApi.Models
{
    public class Funcionario
    {
        public long FuncionarioId { get; set; }
        public string? NomeFuncionario { get; set; }
        public string? NifFuncionario { get; set; }
        public Loja? LojaFuncionario { get; set; }
    }
}