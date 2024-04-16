using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class ResiduosPartida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResiduosPartida { get; set; }
        public int IdPartida { get; set; }
        public int IdResiduos { get; set; }
        public required string CantidadRegistrada { get; set; }

        public required Partida Partida { get; set; }
        public required Residuos Residuos { get; set; }
    }
}