using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class PeriodoLocacao : UserControls          //gerenciado pelo Adm
    {
        [Key]
        public int PeriodoID { get; set; }
        public int CodigoPeriodo { get; set; }
        public decimal Valor { get; set; }              //valor R$ das vagas
        public int QuantidadeVagas { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual TipoVeiculo TipoVeiculo { get; set; }
    }
}