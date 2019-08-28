using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class CordoVeiculo : UserControls       //OPCIONAL
    {
        [Key]
        public int CorId { get; set; }

        public int CodigoCor { get; set; }

        public string Descricao { get; set; }
    }
}