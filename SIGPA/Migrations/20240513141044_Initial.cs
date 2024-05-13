using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGPA.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoResiduos",
                columns: table => new
                {
                    IdEstadoResiduos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstadoResiduos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoResiduos", x => x.IdEstadoResiduos);
                });

            migrationBuilder.CreateTable(
                name: "EstadoRuta",
                columns: table => new
                {
                    IdEstadoRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstadoRuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoRuta", x => x.IdEstadoRuta);
                });

            migrationBuilder.CreateTable(
                name: "MetodoControl",
                columns: table => new
                {
                    IdMetodoControl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMetodoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionMetodoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoControl", x => x.IdMetodoControl);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    IdNivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreNivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.IdNivel);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuarios",
                columns: table => new
                {
                    IdRolUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRolUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuarios", x => x.IdRolUsuario);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculo",
                columns: table => new
                {
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculo", x => x.IdTipoVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombresUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRolUsuario = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_RolUsuarios_IdRolUsuario",
                        column: x => x.IdRolUsuario,
                        principalTable: "RolUsuarios",
                        principalColumn: "IdRolUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_TipoVehiculo_IdTipoVehiculo",
                        column: x => x.IdTipoVehiculo,
                        principalTable: "TipoVehiculo",
                        principalColumn: "IdTipoVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    IdPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaInicioPartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinPartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNivel = table.Column<int>(type: "int", nullable: false),
                    UbicacionJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puntuacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.IdPartida);
                    table.ForeignKey(
                        name: "FK_Partida_Nivel_IdNivel",
                        column: x => x.IdNivel,
                        principalTable: "Nivel",
                        principalColumn: "IdNivel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Residuos",
                columns: table => new
                {
                    IdResiduos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreResiduo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEstadoResiduos = table.Column<int>(type: "int", nullable: false),
                    CantidadRegistrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residuos", x => x.IdResiduos);
                    table.ForeignKey(
                        name: "FK_Residuos_EstadoResiduos_IdEstadoResiduos",
                        column: x => x.IdEstadoResiduos,
                        principalTable: "EstadoResiduos",
                        principalColumn: "IdEstadoResiduos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Residuos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RutaRecolecta",
                columns: table => new
                {
                    IdRutaRecolecta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuntoInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuntoFinalizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstadoRuta = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdVehiculo = table.Column<int>(type: "int", nullable: false),
                    FechaRecoleccion = table.Column<DateOnly>(type: "date", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutaRecolecta", x => x.IdRutaRecolecta);
                    table.ForeignKey(
                        name: "FK_RutaRecolecta_EstadoRuta_IdEstadoRuta",
                        column: x => x.IdEstadoRuta,
                        principalTable: "EstadoRuta",
                        principalColumn: "IdEstadoRuta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutaRecolecta_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutaRecolecta_Vehiculo_IdVehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "IdVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlCalidad",
                columns: table => new
                {
                    IdControlCalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaControl = table.Column<DateOnly>(type: "date", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdResiduo = table.Column<int>(type: "int", nullable: false),
                    IdMetodoControl = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCalidad", x => x.IdControlCalidad);
                    table.ForeignKey(
                        name: "FK_ControlCalidad_MetodoControl_IdMetodoControl",
                        column: x => x.IdMetodoControl,
                        principalTable: "MetodoControl",
                        principalColumn: "IdMetodoControl",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlCalidad_Residuos_IdResiduo",
                        column: x => x.IdResiduo,
                        principalTable: "Residuos",
                        principalColumn: "IdResiduos");
                    table.ForeignKey(
                        name: "FK_ControlCalidad_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResiduosPartida",
                columns: table => new
                {
                    IdResiduosPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPartida = table.Column<int>(type: "int", nullable: false),
                    IdResiduo = table.Column<int>(type: "int", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResiduosPartida", x => x.IdResiduosPartida);
                    table.ForeignKey(
                        name: "FK_ResiduosPartida_Partida_IdPartida",
                        column: x => x.IdPartida,
                        principalTable: "Partida",
                        principalColumn: "IdPartida");
                    table.ForeignKey(
                        name: "FK_ResiduosPartida_Residuos_IdResiduo",
                        column: x => x.IdResiduo,
                        principalTable: "Residuos",
                        principalColumn: "IdResiduos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecolectaResiduos",
                columns: table => new
                {
                    IdRecolectaResiduos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRutaRecolecta = table.Column<int>(type: "int", nullable: false),
                    IdResiduo = table.Column<int>(type: "int", nullable: false),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecolectaResiduos", x => x.IdRecolectaResiduos);
                    table.ForeignKey(
                        name: "FK_RecolectaResiduos_Residuos_IdResiduo",
                        column: x => x.IdResiduo,
                        principalTable: "Residuos",
                        principalColumn: "IdResiduos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecolectaResiduos_RutaRecolecta_IdRutaRecolecta",
                        column: x => x.IdRutaRecolecta,
                        principalTable: "RutaRecolecta",
                        principalColumn: "IdRutaRecolecta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecolectaResiduos_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IdNivel",
                table: "Partida",
                column: "IdNivel");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IdUsuario",
                table: "Partida",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResiduos_IdResiduo",
                table: "RecolectaResiduos",
                column: "IdResiduo");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResiduos_IdRutaRecolecta",
                table: "RecolectaResiduos",
                column: "IdRutaRecolecta");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResiduos_UsuarioIdUsuario",
                table: "RecolectaResiduos",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Residuos_IdEstadoResiduos",
                table: "Residuos",
                column: "IdEstadoResiduos");

            migrationBuilder.CreateIndex(
                name: "IX_Residuos_IdUsuario",
                table: "Residuos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ResiduosPartida_IdPartida",
                table: "ResiduosPartida",
                column: "IdPartida");

            migrationBuilder.CreateIndex(
                name: "IX_ResiduosPartida_IdResiduo",
                table: "ResiduosPartida",
                column: "IdResiduo");

            migrationBuilder.CreateIndex(
                name: "IX_RutaRecolecta_IdEstadoRuta",
                table: "RutaRecolecta",
                column: "IdEstadoRuta");

            migrationBuilder.CreateIndex(
                name: "IX_RutaRecolecta_IdUsuario",
                table: "RutaRecolecta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RutaRecolecta_IdVehiculo",
                table: "RutaRecolecta",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRolUsuario",
                table: "Usuarios",
                column: "IdRolUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_IdTipoVehiculo",
                table: "Vehiculo",
                column: "IdTipoVehiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlCalidad");

            migrationBuilder.DropTable(
                name: "RecolectaResiduos");

            migrationBuilder.DropTable(
                name: "ResiduosPartida");

            migrationBuilder.DropTable(
                name: "MetodoControl");

            migrationBuilder.DropTable(
                name: "RutaRecolecta");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Residuos");

            migrationBuilder.DropTable(
                name: "EstadoRuta");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "EstadoResiduos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoVehiculo");

            migrationBuilder.DropTable(
                name: "RolUsuarios");
        }
    }
}
