using Newtonsoft.Json;
using PadawanProjectGarage.Models.Sistema;
using PadawanProjectGarage.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    //[Table("Locacao")]
    public class Locacao : UserControls
    {
        [Key]
        public int LocacaoID { get; set; }

        [CustomValidFields(Enums.ValidFields.ValidaPlaca)]
        public string Placa { get; set; }

        public int Status { get; set; }

        public bool AceitaTermo { get; set; }

        [ForeignKey("Veiculofk")]
        public TipoVeiculo tipoVeiculo { get; set; }
        public int? Veiculofk { get; set; }

        [ForeignKey("MarcaFK")]
        public Marca marca { get; set; }
        public int? MarcaFK { get; set; }

        [ForeignKey("ModeloFK")]
        public Modelo modelo { get; set; }
        public int? ModeloFK { get; set; }

        [ForeignKey("CordoVeiculoFK")]
        public CordoVeiculo cordoVeiculo { get; set; }
        public int? CordoVeiculoFK { get; set; }

        [ForeignKey("PeriodoLocacaoFK")]
        public PeriodoLocacao periodoLocacao { get; set; }
        public int? PeriodoLocacaoFK { get; set; }

        [ForeignKey("ColaboradorFK")]
        public Colaborador colaborador { get; set; }
        public int? ColaboradorFK { get; set; }

        [ForeignKey("TermoDeLocacaoFK")]
        public TermoDeLocacao termoDeLocacao { get; set; }
        public int? TermoDeLocacaoFK { get; set; }
    }
}