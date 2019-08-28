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
    public class Locacao : UserControls
    {
        [Key]
        public int LocacaoID { get; set; }

        [ForeignKey("Veiculofk")]
        public TipoVeiculo tipoVeiculoFK { get; set; }
        public int? Veiculofk { get; set; }

        [ForeignKey("MarcaFK")]
        public Marca marcaFK { get; set; }
        public int? MarcaFK { get; set; }

        [ForeignKey("ModeloFK")]
        public Modelo modeloFK { get; set; }
        public int? ModeloFK { get; set; }

        [ForeignKey("CordoVeiculoFK")]
        public CordoVeiculo cordoVeiculoFK { get; set; }
        public int? CordoVeiculoFK { get; set; }

        [CustomValidFields(Enums.ValidFields.ValidaPlaca)]
        public string Placa {get; set; }                                //OPCIONAL,.Validação quando for Aut ou Moto (antigo ou novo Mecosul), caso ñ, retornar mensagem verificação

        [ForeignKey("PeriodoLocacaoFK")]
        public PeriodoLocacao periodoLocacaoFK { get; set; }
        public int? PeriodoLocacaoFK { get; set; }

        [ForeignKey("ColaboradorFK")]
        public Colaborador colaboradorFK { get; set; }
        public int? ColaboradorFK { get; set; }
        
        public bool Status { get; set; }                                //o aguardo

        [ForeignKey("ColaboradorFK")]
        public TermoDeLocacao termoDeLocacaoFK { get; set; }
        public int? TermoDeLocacaoFK { get; set; }
    }
}