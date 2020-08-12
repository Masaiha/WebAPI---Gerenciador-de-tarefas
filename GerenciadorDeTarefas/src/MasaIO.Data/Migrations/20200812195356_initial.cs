using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasaIO.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    escudo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taferas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(300)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataUltimaAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    EquipeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taferas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taferas_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taferas_EquipeId",
                table: "Taferas",
                column: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taferas");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
