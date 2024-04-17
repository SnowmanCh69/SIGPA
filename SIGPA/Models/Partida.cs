using Microsoft.EntityFrameworkCore;
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

        [ForeignKey(nameof(Usuario)]
        public int IdUsuario { get; set; }
        public required DateTime FechaInicioPartida { get; set; }
        public required DateTime FechaFinPartida { get; set; }
        [ForeignKey(nameof(Nivel))]
        public int IdNivel { get; set; }
        public required string UbicacionJugador { get; set; }
        public int CantidadVidas { get; set; }
        [ForeignKey(nameof(Residuos))]
        public int IdResiduos { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual Nivel? Nivel { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual Residuos? Residuos { get; set; }

    }
}