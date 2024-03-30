using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class RutaRecolecta
    {
        public required int IdRutaRecolecta { get; set; }
        public required int IdEstadoRuta { get; set; }
        public required int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        [ForeignKey("EstadoRuta")]
        public required EstadoRuta EstadoRuta { get; set; }


    }
}