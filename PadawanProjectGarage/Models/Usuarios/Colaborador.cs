using PadawanProjectGarage.Models.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class Colaborador : UserControls                 //Usuario LOCADOR
    {
        [Key]
        public int ColaboradorId { get; set; }

        public int CodigoColaborador { get; set; }

        [Required]
        [CustomValidFields(Enums.ValidFields.ValidaNome)]
        public string Nome { get; set; }

        [Required]
        [CustomValidFields(Enums.ValidFields.ValidaEmail)]
        public string Email { get; set; }

        [Required]
        //[CustomValidFields(Enums.ValidFields.ValidaIdade)]
        public bool Idoso { get; set; } = false;

        [Required]
        public bool PCD { get; set; } = false;

        [Required]
        public bool PeriodoNoturo { get; set; } = false;            //obrigatorio

        [Required]
        public bool OfereceCarona { get; set; } = false;            //se da carona tem prioridade

        [Required]
        public bool ResideFora { get; set; } = false;               //se for de outra cidade tem prioridade
    }
}