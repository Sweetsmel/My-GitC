using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class Marca      //OPCIONAL
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("TipoVeiculoFK")]
        public TipoVeiculo TipoVeiculo { get; set; }
        public int TipoVeiculoFK { get; set; }

    }
}