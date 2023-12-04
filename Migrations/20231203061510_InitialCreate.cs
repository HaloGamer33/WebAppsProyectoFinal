using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anfitrion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    NoFiestas = table.Column<int>(type: "INTEGER", nullable: false),
                    DineroGastado = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anfitrion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Paga = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dj", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformacionPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titular = table.Column<string>(type: "TEXT", nullable: true),
                    NoTarjeta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnfitrionId = table.Column<int>(type: "INTEGER", nullable: true),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: true),
                    DjId = table.Column<int>(type: "INTEGER", nullable: true),
                    PagoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    NoInvitados = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_Anfitrion_AnfitrionId",
                        column: x => x.AnfitrionId,
                        principalTable: "Anfitrion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evento_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evento_Dj_DjId",
                        column: x => x.DjId,
                        principalTable: "Dj",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evento_InformacionPago_PagoId",
                        column: x => x.PagoId,
                        principalTable: "InformacionPago",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evento_AnfitrionId",
                table: "Evento",
                column: "AnfitrionId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_CategoriaId",
                table: "Evento",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_DjId",
                table: "Evento",
                column: "DjId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_PagoId",
                table: "Evento",
                column: "PagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Anfitrion");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Dj");

            migrationBuilder.DropTable(
                name: "InformacionPago");
        }
    }
}
