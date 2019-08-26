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
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool PCD { get; set; } = true;
        public bool PeriodoTrabalho { get; set; } = true;   //obrigatorio


    }
}