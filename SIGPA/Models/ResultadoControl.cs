namespace SIGPA.Models
{
    public class ResultadoControl
    {
        public required int IdResultadoControl { get; set; }
        public required string NombreResultadoControl { get; set; }
        public required ControlCalidad ControlCalidad { get; set; }
    }
}