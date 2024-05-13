using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateResiduos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residuos_ResiduosPartida_IdResiduosPartida",
                table: "Residuos");

            migrationBuilder.DropForeignKey(
                name: "FK_ResiduosPartida_Residuos_IdResiduo",
                table: "ResiduosPartida");

            migrationBuilder.DropIndex(
                name: "IX_Residuos_IdResiduosPartida",
                table: "Residuos");

            migrationBuilder.DropColumn(
                name: "IdResiduosPartida",
                table: "Residuos");

            migrationBuilder.AddForeignKey(
                name: "FK_ResiduosPartida_Residuos_IdResiduo",
                table: "ResiduosPartida",
                column: "IdResiduo",
                principalTable: "Residuos",
                principalColumn: "IdResiduos",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResiduosPartida_Residuos_IdResiduo",
                table: "ResiduosPartida");

            migrationBuilder.AddColumn<int>(
                name: "IdResiduosPartida",
                table: "Residuos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Residuos_IdResiduosPartida",
                table: "Residuos",
                column: "IdResiduosPartida");

            migrationBuilder.AddForeignKey(
                name: "FK_Residuos_ResiduosPartida_IdResiduosPartida",
                table: "Residuos",
                column: "IdResiduosPartida",
                principalTable: "ResiduosPartida",
                principalColumn: "IdResiduosPartida",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResiduosPartida_Residuos_IdResiduo",
                table: "ResiduosPartida",
                column: "IdResiduo",
                principalTable: "Residuos",
                principalColumn: "IdResiduos");
        }
    }
}
