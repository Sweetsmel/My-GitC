using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class Colaborador : UserControls     //Usuario LOCADOR
    {
        [Key]
        public int ColaboradorId { get; set; }
        public int CodigoColaborador { get; set; }  
        public string Nome { get; set; }
        public int Idade { get; set; }  //aqui se for maior de 60 tem prioridade
        public bool Idoso { get; set; }
        public string Email { get; set; }
        [Required]
        public bool PCD { get; set; } = true;
        [Required]
        public bool PeriodoNoturo { get; set; }   //obrigatorio
        [Required]
        public bool OfereceCarona { get; set; }            //se da carona tem prioridade
        [Required]
        public bool ResideFora { get; set; }    //se for de outra cidade tem prioridade
    }
}