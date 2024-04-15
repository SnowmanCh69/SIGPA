using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class MetodoControl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMetodoControl { get; set; }
        public required string NombreMetodoControl { get; set; }
        public required string DescripcionMetodoControl { get; set; }
    }
}