using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class RutaRecolecta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRutaRecolecta { get; set; }
        public required string PuntoInicio { get; set; }
        public required string PuntoFinalizacion { get; set; }

        [ForeignKey(nameof(EstadoRuta))]
        public int IdEstadoRuta { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(Vehiculo))]
        public int IdVehiculo { get; set; }
        public required DateOnly FechaRecoleccion { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;


        public virtual Usuario? Usuario { get; set; }
        public virtual EstadoRuta? EstadoRuta { get; set; }
        public virtual Vehiculo? Vehiculo { get; set; }


    }
}