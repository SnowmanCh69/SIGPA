
namespace SIGPA.Models
{
    public class Usuario
    {
        public required int IdUsuario { get; set; }
        public required string NombreUsuario { get; set; }
        public required string EmailUsuario { get; set; }
        public required int IdRolUsuario { get; set; }



       
        public required RolUsuario RolUsuario { get; set; }

        public required List<Partida> Partida { get; set; }
        public required List<ControlCalidad> ControlCalidad { get; set; }
        public required List<RutaRecolecta> RutaRecolecta { get; set; }
        public required List<Residuos> Residuos { get; set; }
        public required List<RecolectaResiduos> RecolectaResiduos { get; set; }




    }
}
