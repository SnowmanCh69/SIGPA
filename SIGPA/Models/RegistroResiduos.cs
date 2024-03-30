using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class RegistroResiduos
    {
        public required int IdRegistroResiduos { get; set; }
        public required DateTime FechaRegistro{ get; set; }
        public required string CantidadCascaras { get; set; }
        public required int IdUsuario { get; set; }
        public required int IdEstadoRegistro { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        [ForeignKey("IdEstadoRegistro")]
        public required EstadoRegistro EstadoRegistro { get; set; }

    }
}
