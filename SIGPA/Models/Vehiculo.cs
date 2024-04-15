using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public required int IdTipoVehiculo { get; set; }

        public required TipoVehiculo TipoVehiculo { get; set; }

    }
}