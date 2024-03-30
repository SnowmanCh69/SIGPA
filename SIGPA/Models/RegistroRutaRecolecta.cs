using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class RegistroRutaRecolecta
    {
        public required int IdRegistroRutaRecolecta { get; set; }
        public required DateTime FechaProgramacion { get; set; }
        public required int IdUsuario { get; set; }
        public required int IdRutaRecolecta { get; set; }
        public required int IdRegitroResiduos { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        [ForeignKey("IdRutaRecolecta")]
        public required RutaRecolecta RutaRecolecta { get; set; }

        [ForeignKey("IdRegitroResiduos")]
        public required RegistroResiduos RegistroResiduos { get; set; }

    }
}
