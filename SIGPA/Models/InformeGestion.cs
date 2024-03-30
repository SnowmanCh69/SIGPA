using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class InformeGestion
    {
        public required int IdInformeGestion { get; set; }
        public required DateTime FechaInforme { get; set; }
        public required string ConclucionInforme  { get; set; }
        public required string RecomendacionInforme { get; set; }
        public required int IdUsuario { get; set; }
        public required int IdDatoAnalitico { get; set; }


        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        [ForeignKey("IdDatoAnalitico")]
        public required DatoAnalitico DatoAnalitico { get; set; }
    }
}
