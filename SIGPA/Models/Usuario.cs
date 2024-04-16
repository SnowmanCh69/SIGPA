
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIGPA.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public required string NombreUsuario { get; set; }
        public required string EmailUsuario { get; set; }
        public int IdRolUsuario { get; set; }



       
        public required RolUsuario RolUsuario { get; set; }


        public ICollection<Partida> Partidas { get; set; } = new List<Partida>();
        public List<ControlCalidad> ControlCalidad { get; set; } = new List<ControlCalidad>();
        public List<RutaRecolecta> RutaRecolecta { get; set; } = new List<RutaRecolecta>();
        public List<Residuos> Residuos { get; set; } = new List<Residuos>();
        public ICollection<RecolectaResiduos> RecolectaResiduos { get; set; } = new List<RecolectaResiduos>();




    }
}
