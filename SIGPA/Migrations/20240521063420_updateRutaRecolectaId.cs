using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class updateRutaRecolectaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RutaRecolecta_EstadoRuta_IdEstadoRuta",
                table: "RutaRecolecta");

            migrationBuilder.DropForeignKey(
                name: "FK_RutaRecolecta_Usuarios_IdUsuario",
                table: "RutaRecolecta");

            migrationBuilder.DropForeignKey(
                name: "FK_RutaRecolecta_Vehiculo_IdVehiculo",
                table: "RutaRecolecta");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "RutaRecolecta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RutaRecolecta_UsuarioIdUsuario",
                table: "RutaRecolecta",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_RutaRecolecta_EstadoRuta_IdEstadoRuta",
                table: "RutaRecolecta",
                column: "IdEstadoRuta",
                principalTable: "EstadoRuta",
                principalColumn: "IdEstadoRuta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RutaRecolecta_Usuarios_IdUsuario",
                table: "RutaRecolecta",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RutaRecolecta_Usuarios_UsuarioIdUsuario",
                table: "RutaRecolecta",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_RutaRecolecta_Vehiculo_IdVehiculo",
                table: "RutaRecolecta",
                column: "IdVehiculo",
                principalTable: "Vehiculo",
                principalColumn: "IdVehiculo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RutaRecolecta_EstadoRuta_IdEstadoRuta",
                table: "RutaRecolecta");

            migrationBuilder.DropForeignKey(
                name: "FK_RutaRecolecta_Usuarios_IdUsuario",
                table: "RutaRecolecta");

            migrationBuilder.DropForeignKey(
                name: "FK_RutaRecolecta_Usuarios_UsuarioIdUsuario",
                table: "RutaRecolecta");

            migrationBuilder.DropForeignKey(
                name: "FK_RutaRecolecta_Vehiculo_IdVehiculo",
                table: "RutaRecolecta");

            migrationBuilder.DropIndex(
                name: "IX_RutaRecolecta_UsuarioIdUsuario",
                table: "RutaRecolecta");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "RutaRecolecta");

            migrationBuilder.AddForeignKey(
                name: "FK_RutaRecolecta_EstadoRuta_IdEstadoRuta",
                table: "RutaRecolecta",
                column: "IdEstadoRuta",
                principalTable: "EstadoRuta",
                principalColumn: "IdEstadoRuta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RutaRecolecta_Usuarios_IdUsuario",
                table: "RutaRecolecta",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RutaRecolecta_Vehiculo_IdVehiculo",
                table: "RutaRecolecta",
                column: "IdVehiculo",
                principalTable: "Vehiculo",
                principalColumn: "IdVehiculo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
