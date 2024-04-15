using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class RecolectaControlCalidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRecolectaControlCalidad { get; set; }
        public int IdRecolectaResiduos { get; set; }
        public int IdControlCalidad { get; set; }
        public int IdResultado { get; set; }
        public required string Observaciones { get; set; }

        public required RecolectaResiduos RecolectaResiduos { get; set; }
        public required ControlCalidad ControlCalidad { get; set; }
        public required Resultado Resultado { get; set; }
    }
}