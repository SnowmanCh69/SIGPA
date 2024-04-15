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
                    NombreEstadoResiduos = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    NombreEstadoRuta = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DescripcionMetodoControl = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    NombreNivel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.IdNivel);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    IdResultado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreResultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.IdResultado);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuarios",
                columns: table => new
                {
                    IdRolUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRolUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuarios", x => x.IdRolUsuario);
                });

            migrationBuilder.CreateTable(
                name: "TipoLogro",
                columns: table => new
                {
                    IdTipoLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoLogro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLogro", x => x.IdTipoLogro);
                });

            migrationBuilder.CreateTable(
                name: "TipoResiduos",
                columns: table => new
                {
                    IdTipoResiduos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoResiduos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoResiduos", x => x.IdTipoResiduos);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculo",
                columns: table => new
                {
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRolUsuario = table.Column<int>(type: "int", nullable: false),
                    RolUsuarioIdRolUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_RolUsuarios_RolUsuarioIdRolUsuario",
                        column: x => x.RolUsuarioIdRolUsuario,
                        principalTable: "RolUsuarios",
                        principalColumn: "IdRolUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logro",
                columns: table => new
                {
                    IdLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLogro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionLogro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoLogro = table.Column<int>(type: "int", nullable: false),
                    TipoLogroIdTipoLogro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logro", x => x.IdLogro);
                    table.ForeignKey(
                        name: "FK_Logro_TipoLogro_TipoLogroIdTipoLogro",
                        column: x => x.TipoLogroIdTipoLogro,
                        principalTable: "TipoLogro",
                        principalColumn: "IdTipoLogro",
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
                    TipoVehiculoIdTipoVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_TipoVehiculo_TipoVehiculoIdTipoVehiculo",
                        column: x => x.TipoVehiculoIdTipoVehiculo,
                        principalTable: "TipoVehiculo",
                        principalColumn: "IdTipoVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlCalidad",
                columns: table => new
                {
                    IdControlCalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaControl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdMetodoControl = table.Column<int>(type: "int", nullable: false),
                    MetodoControlIdMetodoControl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCalidad", x => x.IdControlCalidad);
                    table.ForeignKey(
                        name: "FK_ControlCalidad_MetodoControl_MetodoControlIdMetodoControl",
                        column: x => x.MetodoControlIdMetodoControl,
                        principalTable: "MetodoControl",
                        principalColumn: "IdMetodoControl",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlCalidad_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residuos",
                columns: table => new
                {
                    IdResiduo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstadoResiduos = table.Column<int>(type: "int", nullable: false),
                    CantidadRegistrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoResiduos = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    EstadoResiduosIdEstadoResiduos = table.Column<int>(type: "int", nullable: false),
                    TipoResiduosIdTipoResiduos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residuos", x => x.IdResiduo);
                    table.ForeignKey(
                        name: "FK_Residuos_EstadoResiduos_EstadoResiduosIdEstadoResiduos",
                        column: x => x.EstadoResiduosIdEstadoResiduos,
                        principalTable: "EstadoResiduos",
                        principalColumn: "IdEstadoResiduos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Residuos_TipoResiduos_TipoResiduosIdTipoResiduos",
                        column: x => x.TipoResiduosIdTipoResiduos,
                        principalTable: "TipoResiduos",
                        principalColumn: "IdTipoResiduos",
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
                    EstadoRutaIdEstadoRuta = table.Column<int>(type: "int", nullable: false),
                    VehiculoIdVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutaRecolecta", x => x.IdRutaRecolecta);
                    table.ForeignKey(
                        name: "FK_RutaRecolecta_EstadoRuta_EstadoRutaIdEstadoRuta",
                        column: x => x.EstadoRutaIdEstadoRuta,
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
                        name: "FK_RutaRecolecta_Vehiculo_VehiculoIdVehiculo",
                        column: x => x.VehiculoIdVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "IdVehiculo",
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
                    CantidadVidas = table.Column<int>(type: "int", nullable: false),
                    IdResiduos = table.Column<int>(type: "int", nullable: false),
                    NivelIdNivel = table.Column<int>(type: "int", nullable: false),
                    ResiduosIdResiduo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.IdPartida);
                    table.ForeignKey(
                        name: "FK_Partida_Nivel_NivelIdNivel",
                        column: x => x.NivelIdNivel,
                        principalTable: "Nivel",
                        principalColumn: "IdNivel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_Residuos_ResiduosIdResiduo",
                        column: x => x.ResiduosIdResiduo,
                        principalTable: "Residuos",
                        principalColumn: "IdResiduo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecolectaResisiduos",
                columns: table => new
                {
                    IdRecolectaResiduos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRutaRecolecta = table.Column<int>(type: "int", nullable: false),
                    IdResiduos = table.Column<int>(type: "int", nullable: false),
                    CantidadRecolectada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRecoleccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RutaRecolectaIdRutaRecolecta = table.Column<int>(type: "int", nullable: false),
                    ResiduosIdResiduo = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecolectaResisiduos", x => x.IdRecolectaResiduos);
                    table.ForeignKey(
                        name: "FK_RecolectaResisiduos_Residuos_ResiduosIdResiduo",
                        column: x => x.ResiduosIdResiduo,
                        principalTable: "Residuos",
                        principalColumn: "IdResiduo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecolectaResisiduos_RutaRecolecta_RutaRecolectaIdRutaRecolecta",
                        column: x => x.RutaRecolectaIdRutaRecolecta,
                        principalTable: "RutaRecolecta",
                        principalColumn: "IdRutaRecolecta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecolectaResisiduos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartidaLogro",
                columns: table => new
                {
                    IdPartidaLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPartida = table.Column<int>(type: "int", nullable: false),
                    IdLogro = table.Column<int>(type: "int", nullable: false),
                    FechaLogro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartidaIdPartida = table.Column<int>(type: "int", nullable: false),
                    LogroIdLogro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidaLogro", x => x.IdPartidaLogro);
                    table.ForeignKey(
                        name: "FK_PartidaLogro_Logro_LogroIdLogro",
                        column: x => x.LogroIdLogro,
                        principalTable: "Logro",
                        principalColumn: "IdLogro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartidaLogro_Partida_PartidaIdPartida",
                        column: x => x.PartidaIdPartida,
                        principalTable: "Partida",
                        principalColumn: "IdPartida",
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
                    CantidadRegistrada = table.Column<int>(type: "int", nullable: false),
                    PartidaIdPartida = table.Column<int>(type: "int", nullable: false),
                    ResiduosIdResiduo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResiduosPartida", x => x.IdResiduosPartida);
                    table.ForeignKey(
                        name: "FK_ResiduosPartida_Partida_PartidaIdPartida",
                        column: x => x.PartidaIdPartida,
                        principalTable: "Partida",
                        principalColumn: "IdPartida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResiduosPartida_Residuos_ResiduosIdResiduo",
                        column: x => x.ResiduosIdResiduo,
                        principalTable: "Residuos",
                        principalColumn: "IdResiduo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecolectaControlCalidad",
                columns: table => new
                {
                    IdRecolectaControlCalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecolectaResiduos = table.Column<int>(type: "int", nullable: false),
                    IdControlCalidad = table.Column<int>(type: "int", nullable: false),
                    IdResultado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecolectaResiduosIdRecolectaResiduos = table.Column<int>(type: "int", nullable: false),
                    ControlCalidadIdControlCalidad = table.Column<int>(type: "int", nullable: false),
                    ResultadoIdResultado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecolectaControlCalidad", x => x.IdRecolectaControlCalidad);
                    table.ForeignKey(
                        name: "FK_RecolectaControlCalidad_ControlCalidad_ControlCalidadIdControlCalidad",
                        column: x => x.ControlCalidadIdControlCalidad,
                        principalTable: "ControlCalidad",
                        principalColumn: "IdControlCalidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecolectaControlCalidad_RecolectaResisiduos_RecolectaResiduosIdRecolectaResiduos",
                        column: x => x.RecolectaResiduosIdRecolectaResiduos,
                        principalTable: "RecolectaResisiduos",
                        principalColumn: "IdRecolectaResiduos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecolectaControlCalidad_Resultado_ResultadoIdResultado",
                        column: x => x.ResultadoIdResultado,
                        principalTable: "Resultado",
                        principalColumn: "IdResultado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_IdUsuario",
                table: "ControlCalidad",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_MetodoControlIdMetodoControl",
                table: "ControlCalidad",
                column: "MetodoControlIdMetodoControl");

            migrationBuilder.CreateIndex(
                name: "IX_Logro_TipoLogroIdTipoLogro",
                table: "Logro",
                column: "TipoLogroIdTipoLogro");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IdUsuario",
                table: "Partida",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_NivelIdNivel",
                table: "Partida",
                column: "NivelIdNivel");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_ResiduosIdResiduo",
                table: "Partida",
                column: "ResiduosIdResiduo");

            migrationBuilder.CreateIndex(
                name: "IX_PartidaLogro_LogroIdLogro",
                table: "PartidaLogro",
                column: "LogroIdLogro");

            migrationBuilder.CreateIndex(
                name: "IX_PartidaLogro_PartidaIdPartida",
                table: "PartidaLogro",
                column: "PartidaIdPartida");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaControlCalidad_ControlCalidadIdControlCalidad",
                table: "RecolectaControlCalidad",
                column: "ControlCalidadIdControlCalidad");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaControlCalidad_RecolectaResiduosIdRecolectaResiduos",
                table: "RecolectaControlCalidad",
                column: "RecolectaResiduosIdRecolectaResiduos");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaControlCalidad_ResultadoIdResultado",
                table: "RecolectaControlCalidad",
                column: "ResultadoIdResultado");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResisiduos_IdUsuario",
                table: "RecolectaResisiduos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResisiduos_ResiduosIdResiduo",
                table: "RecolectaResisiduos",
                column: "ResiduosIdResiduo");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResisiduos_RutaRecolectaIdRutaRecolecta",
                table: "RecolectaResisiduos",
                column: "RutaRecolectaIdRutaRecolecta");

            migrationBuilder.CreateIndex(
                name: "IX_Residuos_EstadoResiduosIdEstadoResiduos",
                table: "Residuos",
                column: "EstadoResiduosIdEstadoResiduos");

            migrationBuilder.CreateIndex(
                name: "IX_Residuos_IdUsuario",
                table: "Residuos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Residuos_TipoResiduosIdTipoResiduos",
                table: "Residuos",
                column: "TipoResiduosIdTipoResiduos");

            migrationBuilder.CreateIndex(
                name: "IX_ResiduosPartida_PartidaIdPartida",
                table: "ResiduosPartida",
                column: "PartidaIdPartida");

            migrationBuilder.CreateIndex(
                name: "IX_ResiduosPartida_ResiduosIdResiduo",
                table: "ResiduosPartida",
                column: "ResiduosIdResiduo");

            migrationBuilder.CreateIndex(
                name: "IX_RutaRecolecta_EstadoRutaIdEstadoRuta",
                table: "RutaRecolecta",
                column: "EstadoRutaIdEstadoRuta");

            migrationBuilder.CreateIndex(
                name: "IX_RutaRecolecta_IdUsuario",
                table: "RutaRecolecta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RutaRecolecta_VehiculoIdVehiculo",
                table: "RutaRecolecta",
                column: "VehiculoIdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolUsuarioIdRolUsuario",
                table: "Usuarios",
                column: "RolUsuarioIdRolUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_TipoVehiculoIdTipoVehiculo",
                table: "Vehiculo",
                column: "TipoVehiculoIdTipoVehiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartidaLogro");

            migrationBuilder.DropTable(
                name: "RecolectaControlCalidad");

            migrationBuilder.DropTable(
                name: "ResiduosPartida");

            migrationBuilder.DropTable(
                name: "Logro");

            migrationBuilder.DropTable(
                name: "ControlCalidad");

            migrationBuilder.DropTable(
                name: "RecolectaResisiduos");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "TipoLogro");

            migrationBuilder.DropTable(
                name: "MetodoControl");

            migrationBuilder.DropTable(
                name: "RutaRecolecta");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "Residuos");

            migrationBuilder.DropTable(
                name: "EstadoRuta");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "EstadoResiduos");

            migrationBuilder.DropTable(
                name: "TipoResiduos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoVehiculo");

            migrationBuilder.DropTable(
                name: "RolUsuarios");
        }
    }
}
