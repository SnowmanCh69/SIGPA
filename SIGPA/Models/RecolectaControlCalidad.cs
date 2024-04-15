using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class RecolectaControlCalidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRecolectaControlCalidad { get; set; }
        public int IdControlCalidad { get; set; }
        public int IdResultado { get; set; }
        public required string Observaciones { get; set; }


        [ForeignKey("IdControlCalidad")]
        public required ControlCalidad ControlCalidad { get; set; }
        [ForeignKey("IdResultado")]
        public required Resultado Resultado { get; set; }
    }
}