using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class TipoVeiculo : UserControls             //OPCIONAL (User controls pois tem Ativo)
    {
        [Key]
        public int TipoVeiculoID { get; set; }          //O Id dos veículos por tipo cadastrado
        public int CodigoTipo { get; set; }
        public string Descricao { get; set; }           //Automovel, Moto, Bike, Patinete
    }
}