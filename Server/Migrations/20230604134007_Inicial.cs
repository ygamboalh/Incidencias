using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Incidencias.Server.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaTrabajos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HoraInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraCreado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AbiertoPor = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    DiaDeSemana = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaTrabajos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoOcurrencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOcurrencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocurrencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Resumen = table.Column<string>(type: "TEXT", nullable: false),
                    HoraOcurrencia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraCreada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReportadaPor = table.Column<string>(type: "TEXT", nullable: false),
                    TipoOcurrencia = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    DiaTrabajoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocurrencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocurrencias_DiaTrabajos_DiaTrabajoId",
                        column: x => x.DiaTrabajoId,
                        principalTable: "DiaTrabajos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocurrencias_DiaTrabajoId",
                table: "Ocurrencias",
                column: "DiaTrabajoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Ocurrencias");

            migrationBuilder.DropTable(
                name: "TipoOcurrencias");

            migrationBuilder.DropTable(
                name: "DiaTrabajos");
        }
    }
}
