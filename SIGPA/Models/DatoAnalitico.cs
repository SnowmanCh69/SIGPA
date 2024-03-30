namespace SIGPA.Models
{
    public class DatoAnalitico
    {
        public required int IdDatoAnalitico { get; set; }
        public required string CantidadResiduosRecolectados { get; set; }
        public required string CantidadResiduosGeneradoss { get; set; }
        public required string EficienciaRuta { get; set; }
        public required string CalidadResiduos { get; set; }
        public required string ImpactoAmbiental { get; set; }
        public required string ConclucionAnalisis { get; set; }

        public required Usuario Usuario { get; set; }

    }
}