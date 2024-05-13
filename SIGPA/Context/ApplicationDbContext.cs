using SIGPA.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;




namespace SIGPA.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Partida> Partida { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<ControlCalidad> ControlCalidad { get; set; }
        public DbSet<MetodoControl> MetodoControl { get; set; }
        public DbSet<ResiduosPartida> ResiduosPartida { get; set; }
        public DbSet<Residuos> Residuos { get; set; }
        public DbSet<EstadoResiduos> EstadoResiduos { get; set; }
        public DbSet<RecolectaResiduos> RecolectaResiduos { get; set; }
        public DbSet<EstadoRuta> EstadoRuta { get; set; }
        public DbSet<RutaRecolecta> RutaRecolecta { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }


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


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ResiduosPartida>()
                .HasOne(rp => rp.Partida)
                .WithMany(p => p.ResiduosPartidas) // Assuming this is the collection in Partida
                .HasForeignKey(rp => rp.IdPartida)
                .OnDelete(DeleteBehavior.NoAction); // This is the important part

            modelBuilder.Entity<ResiduosPartida>()
                .HasOne(rp => rp.Residuos)
                .WithMany(r => r.ResiduosPartidas) // Assuming this is the collection in Residuos
                .HasForeignKey(rp => rp.IdResiduo)
                .OnDelete(DeleteBehavior.NoAction); // This is the important part


            // Filter entities with IsDeleted = true
            modelBuilder.Entity<ControlCalidad>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<MetodoControl>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<Partida>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<RecolectaResiduos>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<Residuos>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<ResiduosPartida>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<RolUsuario>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<RutaRecolecta>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<TipoVehiculo>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<Vehiculo>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<EstadoRuta>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<EstadoResiduos>().HasQueryFilter(e => e.IsDeleted);
            modelBuilder.Entity<Nivel>().HasQueryFilter(e => e.IsDeleted);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}