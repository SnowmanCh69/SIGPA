using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartidaLogro");

            migrationBuilder.DropTable(
                name: "RecolectaControlCalidad");

            migrationBuilder.DropTable(
                name: "Logro");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropTable(
                name: "TipoLogro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    IdResultado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NombreResultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.IdResultado);
                });

            migrationBuilder.CreateTable(
                name: "TipoLogro",
                columns: table => new
                {
                    IdTipoLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NombreTipoLogro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLogro", x => x.IdTipoLogro);
                });

            migrationBuilder.CreateTable(
                name: "RecolectaControlCalidad",
                columns: table => new
                {
                    IdRecolectaControlCalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdControlCalidad = table.Column<int>(type: "int", nullable: false),
                    IdResultado = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecolectaControlCalidad", x => x.IdRecolectaControlCalidad);
                    table.ForeignKey(
                        name: "FK_RecolectaControlCalidad_ControlCalidad_IdControlCalidad",
                        column: x => x.IdControlCalidad,
                        principalTable: "ControlCalidad",
                        principalColumn: "IdControlCalidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecolectaControlCalidad_Resultado_IdResultado",
                        column: x => x.IdResultado,
                        principalTable: "Resultado",
                        principalColumn: "IdResultado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logro",
                columns: table => new
                {
                    IdLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLogroIdTipoLogro = table.Column<int>(type: "int", nullable: true),
                    DescripcionLogro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoLogro = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NombreLogro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logro", x => x.IdLogro);
                    table.ForeignKey(
                        name: "FK_Logro_TipoLogro_TipoLogroIdTipoLogro",
                        column: x => x.TipoLogroIdTipoLogro,
                        principalTable: "TipoLogro",
                        principalColumn: "IdTipoLogro");
                });

            migrationBuilder.CreateTable(
                name: "PartidaLogro",
                columns: table => new
                {
                    IdPartidaLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLogro = table.Column<int>(type: "int", nullable: false),
                    IdPartida = table.Column<int>(type: "int", nullable: false),
                    FechaLogro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidaLogro", x => x.IdPartidaLogro);
                    table.ForeignKey(
                        name: "FK_PartidaLogro_Logro_IdLogro",
                        column: x => x.IdLogro,
                        principalTable: "Logro",
                        principalColumn: "IdLogro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartidaLogro_Partida_IdPartida",
                        column: x => x.IdPartida,
                        principalTable: "Partida",
                        principalColumn: "IdPartida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logro_TipoLogroIdTipoLogro",
                table: "Logro",
                column: "TipoLogroIdTipoLogro");

            migrationBuilder.CreateIndex(
                name: "IX_PartidaLogro_IdLogro",
                table: "PartidaLogro",
                column: "IdLogro");

            migrationBuilder.CreateIndex(
                name: "IX_PartidaLogro_IdPartida",
                table: "PartidaLogro",
                column: "IdPartida");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaControlCalidad_IdControlCalidad",
                table: "RecolectaControlCalidad",
                column: "IdControlCalidad");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaControlCalidad_IdResultado",
                table: "RecolectaControlCalidad",
                column: "IdResultado");
        }
    }
}
