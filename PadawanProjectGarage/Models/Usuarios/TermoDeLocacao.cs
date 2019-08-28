using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models.Usuarios
{
    public class TermoDeLocacao : UserControls
    {
        [Key]
        public int TermoID { get; set; }

        public string Descricao { get; set; }  //texto formatado
    }
}