using SIGPA.Models;
using Microsoft.EntityFrameworkCore;


namespace SIGPA.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RutaRecolecta> RutaRecolecta { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<ResultaddoControl> ResultaddoControl { get; set; }
        public DbSet<RegistroRutaRecolecta> RegistroRutaRecolectas { get; set; }
        public DbSet<RegistroResiduos> RegistroResiduos { get; set; }
        public DbSet<InventarioAlmacen> InventarioAlamacen { get; set; }
        public DbSet<InformeGestion> InformeGestions { get; set; }
        public DbSet<EstadoRuta> EstadoRuta { get; set; }
        public DbSet<EstadoRegistro> EstadoRegistro { get; set; }
        public DbSet<EstadoCascaras> EstadoCascaras { get; set; }
        public DbSet<DatoAnalitico> DatoAnalitico { get; set; }
        public DbSet<ControlCalidad> ControlCalidad { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
