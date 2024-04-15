using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class RutaRecolecta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRutaRecolecta { get; set; }
        public required string PuntoInicio { get; set; }
        public required string PuntoFinalizacion { get; set; }
        public required int IdEstadoRuta { get; set; }
        public required int IdUsuario { get; set; }
        public required int IdVehiculo { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        public required EstadoRuta EstadoRuta { get; set; }
        public required Vehiculo Vehiculo { get; set; }


    }
}