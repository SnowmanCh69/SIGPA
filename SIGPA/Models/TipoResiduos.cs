using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class TipoResiduos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoResiduos { get; set; }
        public required string NombreTipoResiduos { get; set; }
    }
}