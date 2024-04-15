using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class ControlCalidad
    {
        public required int IdControlCalidad { get; set; }
        public required DateTime FechaControl { get; set; }
        public required int IdUsuario { get; set; }
        public required int IdMetodoControl { get; set; }


        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        public required MetodoControl MetodoControl { get; set; }

    }
}