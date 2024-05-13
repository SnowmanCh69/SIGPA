using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class TipoVehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoVehiculo { get; set; }
        public required string NombreTipoVehiculo { get; set; }

        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;

    }
}