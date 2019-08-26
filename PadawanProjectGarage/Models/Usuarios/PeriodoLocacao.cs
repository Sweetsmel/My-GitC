using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class PeriodoLocacao         //gerenciado pelo Adm
    {
        public int PeriodoId { get; set; }
        public int Codigo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        [ForeignKey("TipoVeiculoFK")]
        public TipoVeiculo TipoVeiculo { get; set; }
        public int TipoVeiculoFK { get; set; }
    }
}