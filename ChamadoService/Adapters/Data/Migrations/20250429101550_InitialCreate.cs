using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteTypeId_EmpresaInfo = table.Column<int>(type: "int", nullable: true),
                    ClienteTypeId_PessoaFisicaInfo = table.Column<int>(type: "int", nullable: true),
                    ClienteTypeId_Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteTypeId_Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteTypeId_CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteTypeId_Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
