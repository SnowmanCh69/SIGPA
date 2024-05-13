using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateControlCalidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlCalidad_MetodoControl_MetodoControlIdMetodoControl",
                table: "ControlCalidad");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlCalidad_Residuos_ResiduoIdResiduos",
                table: "ControlCalidad");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlCalidad_Usuarios_UsuarioIdUsuario",
                table: "ControlCalidad");

            migrationBuilder.DropIndex(
                name: "IX_ControlCalidad_MetodoControlIdMetodoControl",
                table: "ControlCalidad");

            migrationBuilder.DropIndex(
                name: "IX_ControlCalidad_ResiduoIdResiduos",
                table: "ControlCalidad");

            migrationBuilder.DropIndex(
                name: "IX_ControlCalidad_UsuarioIdUsuario",
                table: "ControlCalidad");

            migrationBuilder.DropColumn(
                name: "MetodoControlIdMetodoControl",
                table: "ControlCalidad");

            migrationBuilder.DropColumn(
                name: "ResiduoIdResiduos",
                table: "ControlCalidad");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "ControlCalidad");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_IdMetodoControl",
                table: "ControlCalidad",
                column: "IdMetodoControl");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_IdResiduo",
                table: "ControlCalidad",
                column: "IdResiduo");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_IdUsuario",
                table: "ControlCalidad",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlCalidad_MetodoControl_IdMetodoControl",
                table: "ControlCalidad",
                column: "IdMetodoControl",
                principalTable: "MetodoControl",
                principalColumn: "IdMetodoControl",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlCalidad_Residuos_IdResiduo",
                table: "ControlCalidad",
                column: "IdResiduo",
                principalTable: "Residuos",
                principalColumn: "IdResiduos",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlCalidad_Usuarios_IdUsuario",
                table: "ControlCalidad",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlCalidad_MetodoControl_IdMetodoControl",
                table: "ControlCalidad");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlCalidad_Residuos_IdResiduo",
                table: "ControlCalidad");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlCalidad_Usuarios_IdUsuario",
                table: "ControlCalidad");

            migrationBuilder.DropIndex(
                name: "IX_ControlCalidad_IdMetodoControl",
                table: "ControlCalidad");

            migrationBuilder.DropIndex(
                name: "IX_ControlCalidad_IdResiduo",
                table: "ControlCalidad");

            migrationBuilder.DropIndex(
                name: "IX_ControlCalidad_IdUsuario",
                table: "ControlCalidad");

            migrationBuilder.AddColumn<int>(
                name: "MetodoControlIdMetodoControl",
                table: "ControlCalidad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResiduoIdResiduos",
                table: "ControlCalidad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "ControlCalidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_MetodoControlIdMetodoControl",
                table: "ControlCalidad",
                column: "MetodoControlIdMetodoControl");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_ResiduoIdResiduos",
                table: "ControlCalidad",
                column: "ResiduoIdResiduos");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_UsuarioIdUsuario",
                table: "ControlCalidad",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlCalidad_MetodoControl_MetodoControlIdMetodoControl",
                table: "ControlCalidad",
                column: "MetodoControlIdMetodoControl",
                principalTable: "MetodoControl",
                principalColumn: "IdMetodoControl");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlCalidad_Residuos_ResiduoIdResiduos",
                table: "ControlCalidad",
                column: "ResiduoIdResiduos",
                principalTable: "Residuos",
                principalColumn: "IdResiduos");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlCalidad_Usuarios_UsuarioIdUsuario",
                table: "ControlCalidad",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }
    }
}
