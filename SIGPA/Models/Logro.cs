using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class Logro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogro { get; set; }
        public required string NombreLogro { get; set; }
        public required string DescripcionLogro { get; set; }
        public int IdTipoLogro { get; set; }

        public required TipoLogro TipoLogro { get; set; }
    }
}