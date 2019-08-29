using Newtonsoft.Json;
using PadawanProjectGarage.Models.Sistema;
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

        public int CodigoPeriodo { get; set; }          //Abril a Dezembro

        public decimal Valor { get; set; }              //valor R$ das vagas, diferente para carro e moto

        public int QuantidadeVagas { get; set; }        //por tipo de veiculo

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DataInicio { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DataFim { get; set; }

        [ForeignKey("Veiculofk")]
        public TipoVeiculo tipoVeiculoFK { get; set; }
        public int? Veiculofk { get; set; }
    }
}