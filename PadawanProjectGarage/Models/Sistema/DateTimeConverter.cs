using Antlr4.Runtime.Misc;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PadawanProjectGarage.Models.Sistema
{
    public class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy HH:mm:ss";

            //public void ValidateDate(object source, ServerValidateEventArgs args)

            //{
            //    DateTime dt;
            //    DateTime dtNascimentoMax = DateTime.Now.AddYears(-60);
            //    DateTime dtMax = DateTime.Parse("dd/MM/yyyy");

            //    if (DateTime.TryParse(args.Value, out dt) == false)
            //        args.IsValid = false;

            //    if (dt >= dtNascimentoMax)
            //        args.IsValid = false;
            //    if (dt <= dtMax)
            //        args.IsValid = false;
            //}
        }
    }
}
