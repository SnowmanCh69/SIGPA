using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class EstadoRuta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoRuta { get; set; }
        public required string NombreEstadoRuta { get; set; }

        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;
    }
}