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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    NombreResultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    NombreRolUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    NombreTipoLogro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLogro", x => x.IdTipoLogro);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculo",
                columns: table => new
                {
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IdRolUsuario = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Logro",
                columns: table => new
                {
                    IdLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLogro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionLogro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoLogro = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TipoLogroIdTipoLogro = table.Column<int>(type: "int", nullable: true)
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
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "ControlCalidad",
                columns: table => new
                {
                    IdControlCalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaControl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdMetodoControl = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true),
                    MetodoControlIdMetodoControl = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCalidad", x => x.IdControlCalidad);
                    table.ForeignKey(
                        name: "FK_ControlCalidad_MetodoControl_MetodoControlIdMetodoControl",
                        column: x => x.MetodoControlIdMetodoControl,
                        principalTable: "MetodoControl",
                        principalColumn: "IdMetodoControl");
                    table.ForeignKey(
                        name: "FK_ControlCalidad_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "RecolectaControlCalidad",
                columns: table => new
                {
                    IdRecolectaControlCalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdControlCalidad = table.Column<int>(type: "int", nullable: false),
                    IdResultado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IdResiduo = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ResiduosIdResiduos = table.Column<int>(type: "int", nullable: true)
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
                name: "PartidaLogro",
                columns: table => new
                {
                    IdPartidaLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPartida = table.Column<int>(type: "int", nullable: false),
                    IdLogro = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "RecolectaResiduos",
                columns: table => new
                {
                    IdRecolectaResiduos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRutaRecolecta = table.Column<int>(type: "int", nullable: false),
                    IdResiduo = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    CantidadRecolectada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRecoleccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecolectaResiduos", x => x.IdRecolectaResiduos);
                    table.ForeignKey(
                        name: "FK_RecolectaResiduos_RutaRecolecta_IdRutaRecolecta",
                        column: x => x.IdRutaRecolecta,
                        principalTable: "RutaRecolecta",
                        principalColumn: "IdRutaRecolecta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecolectaResiduos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Residuos",
                columns: table => new
                {
                    IdResiduos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreResiduo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstadoResiduos = table.Column<int>(type: "int", nullable: false),
                    CantidadRegistrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdResiduosPartida = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "ResiduosPartida",
                columns: table => new
                {
                    IdResiduosPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPartida = table.Column<int>(type: "int", nullable: false),
                    IdResiduo = table.Column<int>(type: "int", nullable: false),
                    CantidadRegistrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                        principalColumn: "IdResiduos");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_MetodoControlIdMetodoControl",
                table: "ControlCalidad",
                column: "MetodoControlIdMetodoControl");

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_UsuarioIdUsuario",
                table: "ControlCalidad",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Logro_TipoLogroIdTipoLogro",
                table: "Logro",
                column: "TipoLogroIdTipoLogro");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IdNivel",
                table: "Partida",
                column: "IdNivel");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IdUsuario",
                table: "Partida",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_ResiduosIdResiduos",
                table: "Partida",
                column: "ResiduosIdResiduos");

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

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResiduos_IdResiduo",
                table: "RecolectaResiduos",
                column: "IdResiduo");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResiduos_IdRutaRecolecta",
                table: "RecolectaResiduos",
                column: "IdRutaRecolecta");

            migrationBuilder.CreateIndex(
                name: "IX_RecolectaResiduos_IdUsuario",
                table: "RecolectaResiduos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Residuos_IdEstadoResiduos",
                table: "Residuos",
                column: "IdEstadoResiduos");

            migrationBuilder.CreateIndex(
                name: "IX_Residuos_IdResiduosPartida",
                table: "Residuos",
                column: "IdResiduosPartida");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Partida_Residuos_ResiduosIdResiduos",
                table: "Partida",
                column: "ResiduosIdResiduos",
                principalTable: "Residuos",
                principalColumn: "IdResiduos");

            migrationBuilder.AddForeignKey(
                name: "FK_RecolectaResiduos_Residuos_IdResiduo",
                table: "RecolectaResiduos",
                column: "IdResiduo",
                principalTable: "Residuos",
                principalColumn: "IdResiduos",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Residuos_ResiduosPartida_IdResiduosPartida",
                table: "Residuos",
                column: "IdResiduosPartida",
                principalTable: "ResiduosPartida",
                principalColumn: "IdResiduosPartida",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Usuarios_IdUsuario",
                table: "Partida");

            migrationBuilder.DropForeignKey(
                name: "FK_Residuos_Usuarios_IdUsuario",
                table: "Residuos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Nivel_IdNivel",
                table: "Partida");

            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Residuos_ResiduosIdResiduos",
                table: "Partida");

            migrationBuilder.DropForeignKey(
                name: "FK_ResiduosPartida_Residuos_IdResiduo",
                table: "ResiduosPartida");

            migrationBuilder.DropTable(
                name: "PartidaLogro");

            migrationBuilder.DropTable(
                name: "RecolectaControlCalidad");

            migrationBuilder.DropTable(
                name: "RecolectaResiduos");

            migrationBuilder.DropTable(
                name: "Logro");

            migrationBuilder.DropTable(
                name: "ControlCalidad");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropTable(
                name: "RutaRecolecta");

            migrationBuilder.DropTable(
                name: "TipoLogro");

            migrationBuilder.DropTable(
                name: "MetodoControl");

            migrationBuilder.DropTable(
                name: "EstadoRuta");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "TipoVehiculo");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "RolUsuarios");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "Residuos");

            migrationBuilder.DropTable(
                name: "EstadoResiduos");

            migrationBuilder.DropTable(
                name: "ResiduosPartida");

            migrationBuilder.DropTable(
                name: "Partida");
        }
    }
}
