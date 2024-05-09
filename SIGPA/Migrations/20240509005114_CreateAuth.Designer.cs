﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGPA.Context;

#nullable disable

namespace SIGPA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240509005114_CreateAuth")]
    partial class CreateAuth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SIGPA.Models.ControlCalidad", b =>
                {
                    b.Property<int>("IdControlCalidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdControlCalidad"));

                    b.Property<DateTime>("FechaControl")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMetodoControl")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MetodoControlIdMetodoControl")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdControlCalidad");

                    b.HasIndex("MetodoControlIdMetodoControl");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("ControlCalidad");
                });

            modelBuilder.Entity("SIGPA.Models.EstadoResiduos", b =>
                {
                    b.Property<int>("IdEstadoResiduos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstadoResiduos"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreEstadoResiduos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoResiduos");

                    b.ToTable("EstadoResiduos");
                });

            modelBuilder.Entity("SIGPA.Models.EstadoRuta", b =>
                {
                    b.Property<int>("IdEstadoRuta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstadoRuta"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreEstadoRuta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoRuta");

                    b.ToTable("EstadoRuta");
                });

            modelBuilder.Entity("SIGPA.Models.Logro", b =>
                {
                    b.Property<int>("IdLogro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLogro"));

                    b.Property<string>("DescripcionLogro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoLogro")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreLogro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoLogroIdTipoLogro")
                        .HasColumnType("int");

                    b.HasKey("IdLogro");

                    b.HasIndex("TipoLogroIdTipoLogro");

                    b.ToTable("Logro");
                });

            modelBuilder.Entity("SIGPA.Models.MetodoControl", b =>
                {
                    b.Property<int>("IdMetodoControl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMetodoControl"));

                    b.Property<string>("DescripcionMetodoControl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreMetodoControl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMetodoControl");

                    b.ToTable("MetodoControl");
                });

            modelBuilder.Entity("SIGPA.Models.Nivel", b =>
                {
                    b.Property<int>("IdNivel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNivel"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreNivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdNivel");

                    b.ToTable("Nivel");
                });

            modelBuilder.Entity("SIGPA.Models.Partida", b =>
                {
                    b.Property<int>("IdPartida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPartida"));

                    b.Property<DateTime>("FechaFinPartida")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioPartida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdNivel")
                        .HasColumnType("int");

                    b.Property<int>("IdResiduo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ResiduosIdResiduos")
                        .HasColumnType("int");

                    b.Property<string>("UbicacionJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPartida");

                    b.HasIndex("IdNivel");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("ResiduosIdResiduos");

                    b.ToTable("Partida");
                });

            modelBuilder.Entity("SIGPA.Models.PartidaLogro", b =>
                {
                    b.Property<int>("IdPartidaLogro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPartidaLogro"));

                    b.Property<DateTime>("FechaLogro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLogro")
                        .HasColumnType("int");

                    b.Property<int>("IdPartida")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("IdPartidaLogro");

                    b.HasIndex("IdLogro");

                    b.HasIndex("IdPartida");

                    b.ToTable("PartidaLogro");
                });

            modelBuilder.Entity("SIGPA.Models.RecolectaControlCalidad", b =>
                {
                    b.Property<int>("IdRecolectaControlCalidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecolectaControlCalidad"));

                    b.Property<int>("IdControlCalidad")
                        .HasColumnType("int");

                    b.Property<int>("IdResultado")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRecolectaControlCalidad");

                    b.HasIndex("IdControlCalidad");

                    b.HasIndex("IdResultado");

                    b.ToTable("RecolectaControlCalidad");
                });

            modelBuilder.Entity("SIGPA.Models.RecolectaResiduos", b =>
                {
                    b.Property<int>("IdRecolectaResiduos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecolectaResiduos"));

                    b.Property<string>("CantidadRecolectada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRecoleccion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdResiduo")
                        .HasColumnType("int");

                    b.Property<int>("IdRutaRecolecta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("IdRecolectaResiduos");

                    b.HasIndex("IdResiduo");

                    b.HasIndex("IdRutaRecolecta");

                    b.HasIndex("IdUsuario");

                    b.ToTable("RecolectaResiduos");
                });

            modelBuilder.Entity("SIGPA.Models.Residuos", b =>
                {
                    b.Property<int>("IdResiduos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResiduos"));

                    b.Property<string>("CantidadRegistrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEstadoResiduos")
                        .HasColumnType("int");

                    b.Property<int>("IdResiduosPartida")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreResiduo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdResiduos");

                    b.HasIndex("IdEstadoResiduos");

                    b.HasIndex("IdResiduosPartida");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Residuos");
                });

            modelBuilder.Entity("SIGPA.Models.ResiduosPartida", b =>
                {
                    b.Property<int>("IdResiduosPartida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResiduosPartida"));

                    b.Property<string>("CantidadRegistrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPartida")
                        .HasColumnType("int");

                    b.Property<int>("IdResiduo")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("IdResiduosPartida");

                    b.HasIndex("IdPartida");

                    b.HasIndex("IdResiduo");

                    b.ToTable("ResiduosPartida");
                });

            modelBuilder.Entity("SIGPA.Models.Resultado", b =>
                {
                    b.Property<int>("IdResultado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResultado"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreResultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdResultado");

                    b.ToTable("Resultado");
                });

            modelBuilder.Entity("SIGPA.Models.RolUsuario", b =>
                {
                    b.Property<int>("IdRolUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRolUsuario"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreRolUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRolUsuario");

                    b.ToTable("RolUsuarios");
                });

            modelBuilder.Entity("SIGPA.Models.RutaRecolecta", b =>
                {
                    b.Property<int>("IdRutaRecolecta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRutaRecolecta"));

                    b.Property<int>("IdEstadoRuta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdVehiculo")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PuntoFinalizacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PuntoInicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRutaRecolecta");

                    b.HasIndex("IdEstadoRuta");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("RutaRecolecta");
                });

            modelBuilder.Entity("SIGPA.Models.TipoLogro", b =>
                {
                    b.Property<int>("IdTipoLogro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoLogro"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreTipoLogro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoLogro");

                    b.ToTable("TipoLogro");
                });

            modelBuilder.Entity("SIGPA.Models.TipoVehiculo", b =>
                {
                    b.Property<int>("IdTipoVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoVehiculo"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombreTipoVehiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoVehiculo");

                    b.ToTable("TipoVehiculo");
                });

            modelBuilder.Entity("SIGPA.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("ApellidosUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRolUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NombresUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRolUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SIGPA.Models.Vehiculo", b =>
                {
                    b.Property<int>("IdVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVehiculo"));

                    b.Property<int>("IdTipoVehiculo")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MarcaVehiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModeloVehiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlacaVehiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVehiculo");

                    b.HasIndex("IdTipoVehiculo");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("SIGPA.Models.ControlCalidad", b =>
                {
                    b.HasOne("SIGPA.Models.MetodoControl", "MetodoControl")
                        .WithMany()
                        .HasForeignKey("MetodoControlIdMetodoControl");

                    b.HasOne("SIGPA.Models.Usuario", "Usuario")
                        .WithMany("ControlCalidad")
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("MetodoControl");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SIGPA.Models.Logro", b =>
                {
                    b.HasOne("SIGPA.Models.TipoLogro", "TipoLogro")
                        .WithMany()
                        .HasForeignKey("TipoLogroIdTipoLogro");

                    b.Navigation("TipoLogro");
                });

            modelBuilder.Entity("SIGPA.Models.Partida", b =>
                {
                    b.HasOne("SIGPA.Models.Nivel", "Nivel")
                        .WithMany()
                        .HasForeignKey("IdNivel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Usuario", "Usuario")
                        .WithMany("Partidas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Residuos", "Residuos")
                        .WithMany()
                        .HasForeignKey("ResiduosIdResiduos");

                    b.Navigation("Nivel");

                    b.Navigation("Residuos");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SIGPA.Models.PartidaLogro", b =>
                {
                    b.HasOne("SIGPA.Models.Logro", "Logro")
                        .WithMany()
                        .HasForeignKey("IdLogro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("IdPartida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Logro");

                    b.Navigation("Partida");
                });

            modelBuilder.Entity("SIGPA.Models.RecolectaControlCalidad", b =>
                {
                    b.HasOne("SIGPA.Models.ControlCalidad", "ControlCalidad")
                        .WithMany()
                        .HasForeignKey("IdControlCalidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Resultado", "Resultado")
                        .WithMany()
                        .HasForeignKey("IdResultado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ControlCalidad");

                    b.Navigation("Resultado");
                });

            modelBuilder.Entity("SIGPA.Models.RecolectaResiduos", b =>
                {
                    b.HasOne("SIGPA.Models.Residuos", "Residuos")
                        .WithMany()
                        .HasForeignKey("IdResiduo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.RutaRecolecta", "RutaRecolecta")
                        .WithMany()
                        .HasForeignKey("IdRutaRecolecta")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Usuario", "Usuario")
                        .WithMany("RecolectaResiduos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Residuos");

                    b.Navigation("RutaRecolecta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SIGPA.Models.Residuos", b =>
                {
                    b.HasOne("SIGPA.Models.EstadoResiduos", "EstadoResiduos")
                        .WithMany()
                        .HasForeignKey("IdEstadoResiduos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.ResiduosPartida", "ResiduosPartida")
                        .WithMany()
                        .HasForeignKey("IdResiduosPartida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Usuario", "Usuario")
                        .WithMany("Residuos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoResiduos");

                    b.Navigation("ResiduosPartida");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SIGPA.Models.ResiduosPartida", b =>
                {
                    b.HasOne("SIGPA.Models.Partida", "Partida")
                        .WithMany("ResiduosPartidas")
                        .HasForeignKey("IdPartida")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Residuos", "Residuos")
                        .WithMany("ResiduosPartidas")
                        .HasForeignKey("IdResiduo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Partida");

                    b.Navigation("Residuos");
                });

            modelBuilder.Entity("SIGPA.Models.RutaRecolecta", b =>
                {
                    b.HasOne("SIGPA.Models.EstadoRuta", "EstadoRuta")
                        .WithMany()
                        .HasForeignKey("IdEstadoRuta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Usuario", "Usuario")
                        .WithMany("RutaRecolecta")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGPA.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("IdVehiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoRuta");

                    b.Navigation("Usuario");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("SIGPA.Models.Usuario", b =>
                {
                    b.HasOne("SIGPA.Models.RolUsuario", "RolUsuario")
                        .WithMany()
                        .HasForeignKey("IdRolUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RolUsuario");
                });

            modelBuilder.Entity("SIGPA.Models.Vehiculo", b =>
                {
                    b.HasOne("SIGPA.Models.TipoVehiculo", "TipoVehiculo")
                        .WithMany()
                        .HasForeignKey("IdTipoVehiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoVehiculo");
                });

            modelBuilder.Entity("SIGPA.Models.Partida", b =>
                {
                    b.Navigation("ResiduosPartidas");
                });

            modelBuilder.Entity("SIGPA.Models.Residuos", b =>
                {
                    b.Navigation("ResiduosPartidas");
                });

            modelBuilder.Entity("SIGPA.Models.Usuario", b =>
                {
                    b.Navigation("ControlCalidad");

                    b.Navigation("Partidas");

                    b.Navigation("RecolectaResiduos");

                    b.Navigation("Residuos");

                    b.Navigation("RutaRecolecta");
                });
#pragma warning restore 612, 618
        }
    }
}
