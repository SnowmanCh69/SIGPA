using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class RecolectaResiduos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRecolectaResiduos { get; set; }

        [ForeignKey(nameof(RutaRecolecta))]
        public int IdRutaRecolecta{ get; set; }
        [ForeignKey(nameof(Residuos))]
        public int IdResiduos { get; set; }
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public required string CantidadRecolectada { get; set; }
        public required DateTime FechaRecoleccion { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual RutaRecolecta? RutaRecolecta { get; set; }
        public virtual Residuos? Residuos { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}