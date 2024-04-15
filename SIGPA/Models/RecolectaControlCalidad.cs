namespace SIGPA.Models
{
    public class RecolectaControlCalidad
    {
        public required int IdRecolectaControlCalidad { get; set; }
        public required int IdRecolectaResiduos { get; set; }
        public required int IdControlCalidad { get; set; }
        public required int IdResultado { get; set; }
        public required string Observaciones { get; set; }

        public required RecolectaResiduos RecolectaResiduos { get; set; }
        public required ControlCalidad ControlCalidad { get; set; }
        public required Resultado Resultado { get; set; }
    }
}