using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class ControlCalidad
    {
        public required int IdControlCalidad { get; set; }
        public required DateTime FechaControl { get; set; }
        public required string ObservacionesControl { get; set; }
        public required int IdUsuario { get; set; }
        public required int IdResultaddoControl { get; set; }


        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        [ForeignKey("IdResultaddoControl")]
        public required ResultaddoControl ResultaddoControl { get; set; }

    }
}