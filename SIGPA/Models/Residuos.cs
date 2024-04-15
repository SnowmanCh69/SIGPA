using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class Residuos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResiduo { get; set; }
        public required DateTime FechaRegistro { get; set; }
        public int IdEstadoResiduos { get; set; }
        public required string CantidadRegistrada { get; set; }
        public int IdTipoResiduos { get; set; }
        public int IdUsuario { get; set; }

        public required EstadoResiduos EstadoResiduos { get; set; }
        public required TipoResiduos TipoResiduos { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }


    }
}