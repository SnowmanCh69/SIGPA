using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class MetodoControl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMetodoControl { get; set; }
        public required string NombreMetodoControl { get; set; }
        public required string DescripcionMetodoControl { get; set; }


        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;
    }
}