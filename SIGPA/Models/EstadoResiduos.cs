using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class EstadoResiduos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoResiduos { get; set; }
        public required string NombreEstadoResiduos { get; set; }

        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;
    }
}