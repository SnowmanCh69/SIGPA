using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class Partida
    {
        public required int IdPartida { get; set; }
        public required int IdUsuario { get; set; }
        public required DateTime FechaInicioPartida { get; set; }
        public required DateTime FechaFinPartida { get; set; }
        public required int IdNivel { get; set; }
        public required string UbicacionJugador { get; set; }
        public required int CantidadVidas { get; set; }


        public required Nivel Nivel { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }
        

    }
}