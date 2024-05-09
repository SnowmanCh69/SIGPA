using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadVidas",
                table: "Partida");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "CantidadVidas",
                table: "Partida",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
