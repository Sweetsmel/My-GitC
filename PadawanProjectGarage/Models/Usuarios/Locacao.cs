using PadawanProjectGarage.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public string Placa {get; set; }            //opcional; Validação quando for Aut ou Moto (antigo ou novo Mecosul), caso ñ, retornar mensagem


        [ForeignKey("PeriodoFK")]
        public PeriodoLocacao PeriodoLocacao { get; set; }
        public int PeriodoFK { get; set; }

        [ForeignKey("TermoFK")]
        public TermoDeLocacao TermoDeLocacao { get; set; }
        public int TermoFK { get; set; }

        [ForeignKey("CorFK")]
        public CordoVeiculo CordoVeiculo { get; set; }
        public int CorFK { get; set; }

        [ForeignKey("ColaboradorFK")]
        public Colaborador Colaborador { get; set; }
        public int ColaboradorFK { get; set; }

        [ForeignKey("MarcaFK")]
        public Marca Marca { get; set; }
        public int MarcaFK { get; set; }

        [ForeignKey("ModeloFK")]
        public Modelo Modelo { get; set; }
        public int ModeloFK { get; set; }

    }
}