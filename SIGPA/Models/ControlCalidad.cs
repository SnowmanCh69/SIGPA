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
        public required DateTime FechaControl { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public int IdUsuario { get; set; }
        [ForeignKey(nameof(IdMetodoControl))]
        public int IdMetodoControl { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;


        public virtual Usuario? Usuario { get; set; }
        public virtual MetodoControl? MetodoControl { get; set; }
    }
}
