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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Partida>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Partidas)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecolectaResiduos>()
                .HasOne(r => r.RutaRecolecta)
                .WithMany()
                .HasForeignKey(r => r.IdRutaRecolecta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResiduosPartida>()
                .HasOne(rp => rp.Partida)
                .WithMany(p => p.ResiduosPartidas)
                .HasForeignKey(rp => rp.IdPartida)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ControlCalidad>()
                .HasOne(c => c.Residuo)
                .WithMany()
                .HasForeignKey(c => c.IdResiduo)
                .OnDelete(DeleteBehavior.NoAction); // Cambiar a NO ACTION o SET NULL según lo necesites


            // Restricciones de consulta global para entidades eliminadas
            modelBuilder.Entity<ControlCalidad>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<MetodoControl>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<Partida>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<RecolectaResiduos>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<Residuos>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<ResiduosPartida>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<RolUsuario>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<RutaRecolecta>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<TipoVehiculo>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<Vehiculo>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<EstadoRuta>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<EstadoResiduos>().HasQueryFilter(e => e.IsNotDeleted);
            modelBuilder.Entity<Nivel>().HasQueryFilter(e => e.IsNotDeleted);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}