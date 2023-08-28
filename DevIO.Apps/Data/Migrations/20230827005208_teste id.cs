using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIO.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class testeid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoFornecedor = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoViewModel_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FornecedorViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoFornecedor = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ProdutoViewModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FornecedorViewModel_EnderecoViewModel_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "EnderecoViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoViewModel_FornecedorViewModel_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "FornecedorViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_FornecedorId",
                table: "Endereco",
                column: "FornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoViewModel_FornecedorId",
                table: "EnderecoViewModel",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorViewModel_EnderecoId",
                table: "FornecedorViewModel",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorViewModel_ProdutoViewModelId",
                table: "FornecedorViewModel",
                column: "ProdutoViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoViewModel_FornecedorId",
                table: "ProdutoViewModel",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorViewModel_ProdutoViewModel_ProdutoViewModelId",
                table: "FornecedorViewModel",
                column: "ProdutoViewModelId",
                principalTable: "ProdutoViewModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoViewModel_Fornecedor_FornecedorId",
                table: "EnderecoViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorViewModel_EnderecoViewModel_EnderecoId",
                table: "FornecedorViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorViewModel_ProdutoViewModel_ProdutoViewModelId",
                table: "FornecedorViewModel");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "EnderecoViewModel");

            migrationBuilder.DropTable(
                name: "ProdutoViewModel");

            migrationBuilder.DropTable(
                name: "FornecedorViewModel");
        }
    }
}
