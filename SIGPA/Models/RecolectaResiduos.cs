using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class RecolectaResiduos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRecolectaResiduos { get; set; }
        public required int IdRutaRecolecta{ get; set; }
        public required int IdResiduos { get; set; }
        public required string CantidadRecolectada { get; set; }
        public required DateTime FechaRecoleccion { get; set; }

        public required RutaRecolecta RutaRecolecta { get; set; }
        public required Residuos Residuos { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

    }
}