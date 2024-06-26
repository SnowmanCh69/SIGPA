﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SIGPA.Models
{
    public class Residuos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResiduo { get; set; }

        public required string NombreResiduo { get; set; }
        public required DateOnly FechaRegistro { get; set; }
        [ForeignKey(nameof(EstadoResiduos))]
        public int IdEstadoResiduos { get; set; }

        public required string CantidadRegistrada { get; set; }


        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }



        [JsonIgnore]
        public bool IsNotDeleted { get; set; } = true;

        public virtual EstadoResiduos? EstadoResiduos { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}