using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class ResiduosPartida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResiduosPartida { get; set; }

        [ForeignKey(nameof(Partida))]
        public int IdPartida { get; set; }

        [ForeignKey(nameof(Residuos))]
        public int IdResiduo { get; set; }
        

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual Partida? Partida { get; set; }
        public virtual Residuos? Residuos { get; set; }
    }
}