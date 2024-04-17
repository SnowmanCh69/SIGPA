using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class TipoLogro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoLogro { get; set; }
        public required string NombreTipoLogro { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

    }
}