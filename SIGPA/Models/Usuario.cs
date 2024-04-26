﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public required string NombresUsuario { get; set; }
        public required string ApellidosUsuario { get; set; }
        public required string EmailUsuario { get; set; }

        [ForeignKey(nameof(RolUsuario))]
        public int IdRolUsuario { get; set; }


        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;


        public virtual RolUsuario? RolUsuario { get; set; }


        public virtual ICollection<Partida> Partidas { get; set; } = new List<Partida>();
        public virtual List<ControlCalidad> ControlCalidad { get; set; } = new List<ControlCalidad>();
        public virtual List<RutaRecolecta> RutaRecolecta { get; set; } = new List<RutaRecolecta>();
        public virtual List<Residuos> Residuos { get; set; } = new List<Residuos>();
        public virtual ICollection<RecolectaResiduos> RecolectaResiduos { get; set; } = new List<RecolectaResiduos>();




    }
}
