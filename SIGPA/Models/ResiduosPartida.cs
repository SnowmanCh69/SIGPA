using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class ResiduosPartida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResiduosPartida { get; set; }
        public required int IdPartida { get; set; }
        public required int IdResiduo { get; set; }
        public required int CantidadRegistrada { get; set; }


        public required Partida Partida { get; set; }
        public required Residuos Residuos { get; set; }
    }
}