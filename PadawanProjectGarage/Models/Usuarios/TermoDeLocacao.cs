using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models.Usuarios
{
    public class TermoDeLocacao : UserControls
    {
        [Key]
        public int TermoID { get; set; }

        public string Titulo { get; set; }     //ainda nao foi migrada

        public string Descricao { get; set; }  //texto formatado

        public bool Vigente { get; set; }

    }
}