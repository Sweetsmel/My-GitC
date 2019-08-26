using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class Modelo     //OPCIONAL
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("MarcaFK")]
        public Marca Marca { get; set; }
        public int MarcaFK { get; set; }
    }
}