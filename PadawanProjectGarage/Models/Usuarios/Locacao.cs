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
        [Required]
        public virtual TipoVeiculo CodigoTipo { get; set; }

        public virtual Marca CodigoMarca { get; set; }

        public virtual Modelo CodigoModelo { get; set; }

        public virtual CordoVeiculo CodigoCor { get; set; }

        public string Placa {get; set; }                                //OPCIONAL,.Validação quando for Aut ou Moto (antigo ou novo Mecosul), caso ñ, retornar mensagem verificação
        [Required]
        public virtual PeriodoLocacao CodigoPeriodo { get; set; }
        [Required]
        public virtual Colaborador CodigoColaborador { get; set; }
        [Required]
        public int Status { get; set; }                                 //o aguardo
        [Required]
        public virtual TermoDeLocacao TermoDeLocacao { get; set; }
    }
}