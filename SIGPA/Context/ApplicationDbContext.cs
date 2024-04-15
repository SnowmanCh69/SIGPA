using SIGPA.Models;
using Microsoft.EntityFrameworkCore;


namespace SIGPA.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TipoLogro> TipoLogro { get; set; }
        public DbSet<Logro> Logro { get; set; }
        public DbSet<PartidaLogro> PartidaLogro { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<ControlCalidad> ControlCalidad { get; set; }
        public DbSet<MetodoControl> MetodoControl { get; set; }
        public DbSet<ResiduosPartida> ResiduosPartida { get; set; }
        public DbSet<Residuos> Residuos { get; set; }
        public DbSet<EstadoResiduos> EstadoResiduos { get; set; }
        public DbSet<TipoResiduos> TipoResiduos { get; set; }
        public DbSet<RecolectaResiduos> RecolectaResisiduos { get; set; }
        public DbSet<RecolectaControlCalidad> RecolectaControlCalidad { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<EstadoRuta> EstadoRuta { get; set; }
        public DbSet<RutaRecolecta> RutaRecolecta { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculo { get; set; }
  

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
