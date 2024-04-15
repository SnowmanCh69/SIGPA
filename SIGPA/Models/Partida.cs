﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPartida { get; set; }
        public required int IdUsuario { get; set; }
        public required DateTime FechaInicioPartida { get; set; }
        public required DateTime FechaFinPartida { get; set; }
        public required int IdNivel { get; set; }
        public required string UbicacionJugador { get; set; }
        public required int CantidadVidas { get; set; }
        public required int IdResiduos { get; set; }


        public required Nivel Nivel { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }
        public required Residuos Residuos { get; set; }
        

    }
}