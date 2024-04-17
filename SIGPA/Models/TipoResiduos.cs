using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class TipoResiduos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoResiduos { get; set; }
        public required string NombreTipoResiduos { get; set; }


        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

    }
}