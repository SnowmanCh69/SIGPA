using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class updatePartidaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Puntuacion",
                table: "Partida",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puntuacion",
                table: "Partida");
        }
    }
}
