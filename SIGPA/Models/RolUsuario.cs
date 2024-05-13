using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class RolUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRolUsuario { get; set; }
        public required string NombreRolUsuario { get; set; }

        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;

    }
}

