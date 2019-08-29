using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models
{
    public class Administrador : UserControls   //Usuario GESTOR DAS VAGAS
    {
        [Key]
        public int AdministradorId { get; set; }

        [Required]
        //[StringLength(1000)]
        public string Nome { get; set; }

        public string Email { get; set; }
    }
}