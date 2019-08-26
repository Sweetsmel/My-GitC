using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class TipoVeiculo                     //automovel, moto, bike ou patinete    OPCIONAL
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Tipo { get; set; }

    }
}