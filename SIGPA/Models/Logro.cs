using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace SIGPA.Models
{
    public class Logro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogro { get; set; }
        public required string NombreLogro { get; set; }
        public required string DescripcionLogro { get; set; }

        [ForeignKey(nameof(IdTipoLogro))]
        public int IdTipoLogro { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual TipoLogro? TipoLogro { get; set; }
    }
}