using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class ControlCalidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdControlCalidad { get; set; }
        public required DateOnly FechaControl { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(Residuo))]
        public int IdResiduo { get; set; }

        [ForeignKey(nameof(MetodoControl))]
        public int IdMetodoControl { get; set; }

        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;


        public virtual Usuario? Usuario { get; set; }
        public virtual Residuos? Residuo { get; set; }
        public virtual MetodoControl? MetodoControl { get; set; }
    }
}