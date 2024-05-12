using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class updateModelRutaRecolecta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRecoleccion",
                table: "RecolectaResiduos");

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaRecoleccion",
                table: "RutaRecolecta",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRecoleccion",
                table: "RutaRecolecta");

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaRecoleccion",
                table: "RecolectaResiduos",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
