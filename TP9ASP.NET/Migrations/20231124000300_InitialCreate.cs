using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMyCadoApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamaDeProdutos",
                columns: table => new
                {
                    GamaId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiglaGama = table.Column<string>(type: "TEXT", nullable: true),
                    NomeGama = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamaDeProdutos", x => x.GamaId);
                });

            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    LojaId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeLoja = table.Column<string>(type: "TEXT", nullable: true),
                    LocalizacaoLoja = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.LojaId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFuncionario = table.Column<string>(type: "TEXT", nullable: true),
                    NifFuncionario = table.Column<string>(type: "TEXT", nullable: true),
                    LojaFuncionarioLojaId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Lojas_LojaFuncionarioLojaId",
                        column: x => x.LojaFuncionarioLojaId,
                        principalTable: "Lojas",
                        principalColumn: "LojaId");
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoProduto = table.Column<string>(type: "TEXT", nullable: true),
                    NomeProduto = table.Column<string>(type: "TEXT", nullable: true),
                    PrecoUnitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantidadeStock = table.Column<int>(type: "INTEGER", nullable: false),
                    GamaProdutoGamaId = table.Column<long>(type: "INTEGER", nullable: true),
                    LojaProdutoLojaId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_GamaDeProdutos_GamaProdutoGamaId",
                        column: x => x.GamaProdutoGamaId,
                        principalTable: "GamaDeProdutos",
                        principalColumn: "GamaId");
                    table.ForeignKey(
                        name: "FK_Produtos_Lojas_LojaProdutoLojaId",
                        column: x => x.LojaProdutoLojaId,
                        principalTable: "Lojas",
                        principalColumn: "LojaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_LojaFuncionarioLojaId",
                table: "Funcionarios",
                column: "LojaFuncionarioLojaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_GamaProdutoGamaId",
                table: "Produtos",
                column: "GamaProdutoGamaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_LojaProdutoLojaId",
                table: "Produtos",
                column: "LojaProdutoLojaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "GamaDeProdutos");

            migrationBuilder.DropTable(
                name: "Lojas");
        }
    }
}
