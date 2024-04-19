using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    
        public class RecolectaControlCalidad
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int IdRecolectaControlCalidad { get; set; }

            [ForeignKey(nameof(ControlCalidad))]
            public int IdControlCalidad { get; set; }

            [ForeignKey(nameof(Resultado))]
            public int IdResultado { get; set; }

            public required string Observaciones { get; set; }

            [JsonIgnore]
            public bool IsDeleted { get; set; } = true;



            public virtual ControlCalidad? ControlCalidad { get; set; }
            public virtual Resultado? Resultado { get; set; }
        }
}