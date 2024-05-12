using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class updatePartida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Residuos_ResiduosIdResiduos",
                table: "Partida");

            migrationBuilder.DropForeignKey(
                name: "FK_RecolectaResiduos_Usuarios_IdUsuario",
                table: "RecolectaResiduos");

            migrationBuilder.DropIndex(
                name: "IX_RecolectaResiduos_IdUsuario",
                table: "RecolectaResiduos");

            migrationBuilder.DropIndex(
                name: "IX_Partida_ResiduosIdResiduos",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "CantidadRegistrada",
                table: "ResiduosPartida");

            migrationBuilder.DropColumn(
                name: "CantidadRecolectada",
                table: "RecolectaResiduos");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "RecolectaResiduos");

            migrationBuilder.DropColumn(
                name: "IdResiduo",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "ResiduosIdResiduos",
                table: "Partida");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "RecolectaResiduos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResiduos_UsuarioIdUsuario",
                table: "RecolectaResiduos",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_RecolectaResiduos_Usuarios_UsuarioIdUsuario",
                table: "RecolectaResiduos",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecolectaResiduos_Usuarios_UsuarioIdUsuario",
                table: "RecolectaResiduos");

            migrationBuilder.DropIndex(
                name: "IX_RecolectaResiduos_UsuarioIdUsuario",
                table: "RecolectaResiduos");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "RecolectaResiduos");

            migrationBuilder.AddColumn<string>(
                name: "CantidadRegistrada",
                table: "ResiduosPartida",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CantidadRecolectada",
                table: "RecolectaResiduos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "RecolectaResiduos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdResiduo",
                table: "Partida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResiduosIdResiduos",
                table: "Partida",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResiduos_IdUsuario",
                table: "RecolectaResiduos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_ResiduosIdResiduos",
                table: "Partida",
                column: "ResiduosIdResiduos");

            migrationBuilder.AddForeignKey(
                name: "FK_Partida_Residuos_ResiduosIdResiduos",
                table: "Partida",
                column: "ResiduosIdResiduos",
                principalTable: "Residuos",
                principalColumn: "IdResiduos");

            migrationBuilder.AddForeignKey(
                name: "FK_RecolectaResiduos_Usuarios_IdUsuario",
                table: "RecolectaResiduos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }
    }
}
