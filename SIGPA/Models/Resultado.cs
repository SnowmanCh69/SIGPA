using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class Resultado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResultado { get; set; }
        public required string NombreResultado { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;
    }
}