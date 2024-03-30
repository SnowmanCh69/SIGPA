namespace SIGPA.Models
{
    public class EstadoRegistro
    {
        public required int IdEstadoRegistro { get; set; }
        public required string NombreEstadoRegistro { get; set; }
        public required RegistroResiduos RegistroResiduos { get; set; }
    }
}