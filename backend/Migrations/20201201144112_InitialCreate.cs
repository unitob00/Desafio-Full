using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TituloEmAtraso.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TituloAtraso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroTitulo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Juros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TituloAtraso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTituloAtraso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloAtrasoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcela_TituloAtraso_TituloAtrasoId",
                        column: x => x.TituloAtrasoId,
                        principalTable: "TituloAtraso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_TituloAtrasoId",
                table: "Parcela",
                column: "TituloAtrasoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "TituloAtraso");
        }
    }
}
