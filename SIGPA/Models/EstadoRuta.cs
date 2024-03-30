namespace SIGPA.Models
{
    public class EstadoRuta
    {
        public required int IdEstadoRuta { get; set; }
        public required string NombreEstadoRuta { get; set; }
        public required RutaRecolecta RutaRecolecta { get; set; }
    }
}