using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIO.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereços_Fornecedores_FornecedorId",
                table: "Endereços");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereços",
                table: "Endereços");

            migrationBuilder.RenameTable(
                name: "Endereços",
                newName: "Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_Endereços_FornecedorId",
                table: "Enderecos",
                newName: "IX_Enderecos_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereços");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_FornecedorId",
                table: "Endereços",
                newName: "IX_Endereços_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereços",
                table: "Endereços",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereços_Fornecedores_FornecedorId",
                table: "Endereços",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
