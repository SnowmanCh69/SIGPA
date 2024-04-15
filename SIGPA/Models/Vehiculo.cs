namespace SIGPA.Models
{
    public class Vehiculo
    {
        public required int IdVehiculo { get; set; }
        public required string MarcaVehiculo { get; set; }
        public required string ModeloVehiculo { get; set; }
        public required string PlacaVehiculo{ get; set; }
        public required int IdTipoVehiculo { get; set; }

        public required TipoVehiculo TipoVehiculo { get; set; }

    }
}