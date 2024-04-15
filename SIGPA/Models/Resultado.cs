using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class Resultado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResultado { get; set; }
        public required string NombreResultado { get; set; }
    }
}