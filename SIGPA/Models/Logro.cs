namespace SIGPA.Models
{
    public class Logro
    {
        public required int IdLogro { get; set; }
        public required string NombreLogro { get; set; }
        public required string DescripcionLogro { get; set; }
        public required int IdTipoLogro { get; set; }

        public required TipoLogro TipoLogro { get; set; }
    }
}