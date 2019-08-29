using Newtonsoft.Json;
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

        [Required]
        //[StringLength(1000)]
        public string Descricao { get; set; }

        [ForeignKey("VeiculoFK")]
        public  TipoVeiculo tipoVeiculo { get; set; }
        public int? VeiculoFK { get; set; }                  //? PARA ACEITAR NULO
    }
}