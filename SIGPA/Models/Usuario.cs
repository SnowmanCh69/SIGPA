using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class Usuario
    {
        public required int IdUsuario { get; set; }
        public required string NombreUsuario { get; set; }

        public required string EmailUsuario { get; set; }

        public required int IdRolUsuario { get; set; }



        [ForeignKey("IdRolUsuario")]
        public required RolUsuario RolUsuario { get; set; }

        public required List<InformeGestion> InformeGestion { get; set; }
        public required List<InventarioAlmacen> InventarioAlmacen { get; set; }
        public required List<ControlCalidad> ControlCalidad { get; set; }
        public required List<RutaRecolecta> RutaRecolecta { get; set; }
        public required List<RegistroRutaRecolecta> RegistroRutaRecolecta { get; set; }
        public required List<RegistroResiduos> RegistroResiduos { get; set; }



    }
}
