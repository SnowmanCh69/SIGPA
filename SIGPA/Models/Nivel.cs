using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class Nivel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNivel { get; set; }
        public required string NombreNivel { get; set; }

        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;
    }
}