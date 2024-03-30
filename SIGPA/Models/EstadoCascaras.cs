namespace SIGPA.Models
{
    public class EstadoCascaras
    {
        public required int IdEstadoCascaras { get; set; }
        public required string NombreEstadoCascaras { get; set; }
        public required InventarioAlmacen inventarioAlmacen { get; set; }
    }
}