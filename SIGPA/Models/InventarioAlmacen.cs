using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class InventarioAlmacen
    {
        public required int IdInventarioAlmacen { get; set; }
        public required DateTime FechaIngreso { get; set; }
        public required string CantidadIngresada { get; set; }
        public required int IdEstadoCascaras{ get; set; }
        public required int IdUsuario { get; set; }


        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        [ForeignKey("IdEstadoCascaras")]
        public required EstadoCascaras EstadoCascaras { get; set; }
    }
}