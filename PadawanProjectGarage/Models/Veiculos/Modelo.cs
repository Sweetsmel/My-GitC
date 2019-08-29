using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class Modelo : UserControls     //OPCIONAL
    {
        [Key]
        public int ModeloID { get; set; }

        public int CodigoModelo { get; set; }       //foi posto codgmarca

        [Required]
        //[StringLength(1000)]
        public string Descricao { get; set; }

        [ForeignKey("MarcaFK")]
        public Marca marca { get; set; }
        public int? MarcaFK { get; set; }
    }
}