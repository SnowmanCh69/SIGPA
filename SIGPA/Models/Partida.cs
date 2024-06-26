﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace SIGPA.Models
{
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPartida { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public required DateTime FechaInicioPartida { get; set; }
        public DateTime FechaFinPartida { get; set; }
        [ForeignKey(nameof(Nivel))]
        public int IdNivel { get; set; }
        public required string UbicacionJugador { get; set; }
        public required string Puntuacion{ get; set; }
  

        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;

        public virtual Nivel? Nivel { get; set; }
        public virtual Usuario? Usuario { get; set; }


        public virtual ICollection<ResiduosPartida> ResiduosPartidas { get; set; }

    }
}