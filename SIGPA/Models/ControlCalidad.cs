using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPA.Models
{
    public class ControlCalidad
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int IdControlCalidad { get; set; }
        public required DateTime FechaControl { get; set; }
        public int IdUsuario { get; set; }
        public int IdMetodoControl { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        public required MetodoControl MetodoControl { get; set; }
    }
}
