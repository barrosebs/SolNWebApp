using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolNWebApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atleta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    NomeSocial = table.Column<string>(nullable: true),
                    Posicao = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoDoAtleta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Situacao = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    AtletaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoDoAtleta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituacaoDoAtleta_Atleta_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atleta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoDoAtleta_AtletaId",
                table: "SituacaoDoAtleta",
                column: "AtletaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SituacaoDoAtleta");

            migrationBuilder.DropTable(
                name: "Atleta");
        }
    }
}
