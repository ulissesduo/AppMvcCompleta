using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIO.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class semViewModelContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedorId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorViewModel_EnderecoViewModel_EnderecoId",
                table: "FornecedorViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorViewModel_ProdutoViewModel_ProdutoViewModelId",
                table: "FornecedorViewModel");

            migrationBuilder.DropTable(
                name: "EnderecoViewModel");

            migrationBuilder.DropTable(
                name: "ProdutoViewModel");

            migrationBuilder.DropTable(
                name: "FornecedorViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Endereços");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produtos",
                newName: "IX_Produtos_FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_FornecedorId",
                table: "Endereços",
                newName: "IX_Endereços_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereços_Fornecedores_FornecedorId",
                table: "Endereços");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereços",
                table: "Endereços");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "Endereços",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produto",
                newName: "IX_Produto_FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Endereços_FornecedorId",
                table: "Endereco",
                newName: "IX_Endereco_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EnderecoViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "FornecedorViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdutoViewModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoFornecedor = table.Column<int>(type: "int", nullable: false)
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
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "IX_ProdutoViewModel_FornecedorId",
                table: "ProdutoViewModel",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedorId",
                table: "Endereco",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorId",
                table: "Produto",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorViewModel_ProdutoViewModel_ProdutoViewModelId",
                table: "FornecedorViewModel",
                column: "ProdutoViewModelId",
                principalTable: "ProdutoViewModel",
                principalColumn: "Id");
        }
    }
}
