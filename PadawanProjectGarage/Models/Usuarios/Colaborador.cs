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

        [CustomValidFields(Enums.ValidFields.ValidaNome)]
        public string Nome { get; set; }

        //[CustomValidFields(Enums.ValidFields.ValidaIdade)]
        public int Idade { get; set; }                     //aqui se for maior de 60 tem prioridade

        [CustomValidFields(Enums.ValidFields.ValidaEmail)]
        public string Email { get; set; }

        public bool PCD { get; set; } = true;

        public bool PeriodoNoturo { get; set; }            //obrigatorio

        public bool OfereceCarona { get; set; }            //se da carona tem prioridade

        public bool ResideFora { get; set; }               //se for de outra cidade tem prioridade
    }
}