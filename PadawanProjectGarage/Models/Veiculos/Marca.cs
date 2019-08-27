using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class Marca : UserControls     //OPCIONAL
    {
        [Key]
        public int MarcaID { get; set; }
        public int CodigoMarca { get; set; }
        public string Descricao { get; set; }

        public virtual TipoVeiculo CodigoTipo { get; set; }

    }
}