using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class PartidaLogro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPartidaLogro { get; set; }

        [ForeignKey(nameof(Partida))]
        public int IdPartida { get; set; }
        [ForeignKey(nameof(Logro))]
        public int IdLogro { get; set; }
        public required DateTime FechaLogro { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual Partida? Partida { get; set; }
        public virtual Logro? Logro { get; set; }
    }
}