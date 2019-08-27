using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PadawanProjectGarage.Models.Sistema
{
    public class CustomValidFields
    {
        GaragemContext dB = new GaragemContext();

        

        private ValidationResult ValidarEmail(object value, string displayField)
        {
            bool result = Regex.IsMatch(value.ToString(), @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult($"O campo {displayField} é inválido!");     //displayField: nomezinho da label pedindo o email
        }
        private ValidationResult ValidarNome(object value, string displayField)
        {
            bool result = Regex.IsMatch(value.ToString(), "^(([a-zA-Z ]|[é])*)$");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult($"O campo {displayField} é inválido!");     //displayField: nomezinho da label pedindo o email
        }
        private ValidationResult ValidarPLaca(object placa, string displayField)
        {
            Locacao placas = dB.Locacaos.FirstOrDefault(x => x.Placa == placa.ToString());

            var placaBR = Regex.IsMatch(placa.ToString(), @"^[a-zA-Z]{3}[0-9]{4}$");
            var placaMerc = Regex.IsMatch(placa.ToString(), @"^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");
            var placaMoto = Regex.IsMatch(placa.ToString(), @"^[a-zA-Z]{3}[0-9]{2}[a-zA-Z]{1}[0-9]{1}$");

            if (placas == null)

                return ValidationResult.Success;
            else
                return new ValidationResult("A placa informada já está cadastrada no sistema!");

            if (placaBR && placaMerc && placaMoto)
                return ValidationResult.Success;

            return new ValidationResult("A placa informada não está no formato aceitável!");     //displayField: nomezinho da label pedindo o email
        }

    }
}