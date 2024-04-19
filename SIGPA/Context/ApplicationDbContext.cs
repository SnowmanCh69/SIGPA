using SIGPA.Models;
using Microsoft.EntityFrameworkCore;
using SIGPA.Models.SIGPA.Models;


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
        public DbSet<RecolectaResiduos> RecolectaResiduos { get; set; }
        public DbSet<RecolectaControlCalidad> RecolectaControlCalidad { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<EstadoRuta> EstadoRuta { get; set; }
        public DbSet<RutaRecolecta> RutaRecolecta { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partida>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Partidas) // Indica que un usuario puede tener varias partidas
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecolectaResiduos>()
                .HasOne(r => r.RutaRecolecta)
                .WithMany()
                .HasForeignKey(r => r.IdRutaRecolecta)
                .OnDelete(DeleteBehavior.Restrict); // Especifica el comportamiento al eliminar

            modelBuilder.Entity<RecolectaResiduos>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.RecolectaResiduos)
                .HasForeignKey(r => r.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction); // Especifica la opción ON DELETE aquí

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ResiduosPartida>()
                .HasOne(rp => rp.Residuos)
                .WithOne(r => r.ResiduosPartida)
                .HasForeignKey<ResiduosPartida>(rp => rp.IdResiduos)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);


        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
