using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteTypeId_EmpresaInfo",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ClienteTypeId_PessoaFisicaInfo",
                table: "Clientes",
                newName: "ClienteTypeId_ClienteTypeInfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteTypeId_ClienteTypeInfo",
                table: "Clientes",
                newName: "ClienteTypeId_PessoaFisicaInfo");

            migrationBuilder.AddColumn<int>(
                name: "ClienteTypeId_EmpresaInfo",
                table: "Clientes",
                type: "int",
                nullable: true);
        }
    }
}
