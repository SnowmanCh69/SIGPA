using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class RecolectaResiduos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRecolectaResiduos { get; set; }
        public int IdRutaRecolecta{ get; set; }
        public int IdResiduos { get; set; }
        public int IdUsuario { get; set; }
        public required string CantidadRecolectada { get; set; }
        public required DateTime FechaRecoleccion { get; set; }


        [ForeignKey("IdRutaRecolecta")]
        public required RutaRecolecta RutaRecolecta { get; set; }

        [ForeignKey("IdResiduos")]
        public required Residuos Residuos { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }
    }
}