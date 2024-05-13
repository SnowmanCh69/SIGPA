using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVehiculo { get; set; }
        public required string MarcaVehiculo { get; set; }
        public required string ModeloVehiculo { get; set; }
        public required string PlacaVehiculo{ get; set; }

        [ForeignKey(nameof(TipoVehiculo))]
        public int IdTipoVehiculo { get; set; }

        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;


        public virtual TipoVehiculo? TipoVehiculo { get; set; }

    }
}