using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class PartidaLogro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPartidaLogro { get; set; }
        public required int IdPartida { get; set; }
        public required int IdLogro { get; set; }
        public required DateTime FechaLogro { get; set; }

        public required Partida Partida { get; set; }
        public required Logro Logro { get; set; }
    }
}