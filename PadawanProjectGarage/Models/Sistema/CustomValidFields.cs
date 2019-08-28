using PadawanProjectGarage.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PadawanProjectGarage.Models.Sistema
{
    public class CustomValidFields : ValidationAttribute
    {
        GaragemContext dB = new GaragemContext();

        private ValidFields typeField;

        public CustomValidFields(ValidFields type)
        {
            typeField = type;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                switch (typeField)
                {
                    case ValidFields.ValidaNome: { return ValidarNome(value, validationContext.DisplayName); }
                    case ValidFields.ValidaEmail: { return ValidarEmail(value, validationContext.DisplayName); }
                    case ValidFields.ValidaPlaca: { return ValidarPLaca(value, validationContext.DisplayName); }
                    //case ValidFields.ValidaTermo: { }
                    //case ValidFields.ValidaStatus: { return ValidaStatus(value, validationContext.DisplayName); }
                    case ValidFields.ValidaDatas: { return ValidarData(value, validationContext.DisplayName); }
                    //case ValidFields.ValidaIdade: { return ValidarIdade(value, validationContext.DisplayName); }
                    default:
                        break;
                }
            }
            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório!");
        }
        private ValidationResult ValidarNome(object nome, string displayField)
        {
            bool result = Regex.IsMatch(nome.ToString(), "^(([a-zA-Z ]|[é])*)$");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult($"O campo {displayField} não está no formato aceitável!");     //displayField: nomezinho da label pedindo o email
        }
        private ValidationResult ValidarEmail(object email, string displayField)
        {
            bool result = Regex.IsMatch(email.ToString(), @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult($"O campo {displayField} não está no formato aceitável!");     //displayField: nomezinho da label pedindo o email
        }
        private ValidationResult ValidarPLaca(object placa, string displayField)
        {
            bool placaBr =   Regex.IsMatch(placa.ToString(), @"^[a-zA-Z]{3}[-][0-9]{4}$");
            bool placaMerc = Regex.IsMatch(placa.ToString(), @"^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");
            bool placaMoto = Regex.IsMatch(placa.ToString(), @"^[a-zA-Z]{3}[0-9]{2}[a-zA-Z]{1}[0-9]{1}$");

            if (placaBr || placaMerc || placaMoto)
            {
                Locacao locacao = dB.Locacaos.FirstOrDefault(x => x.Placa == placa.ToString());  //lambda

                if (locacao == null)
                    return ValidationResult.Success;
                else
                    return new ValidationResult($"O campo {displayField} já está cadastrado no sistema!");
            }
            return new ValidationResult($"O campo {displayField} não está no formato aceitável!"); 
        }
        private ValidationResult ValidarData(object data, string displayField)
        {
            DateTime dt;

            bool result = DateTime.TryParse("dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                //Regex.IsMatch(data.ToString(), @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult($"O campo {displayField} não está no formato aceitável!");
        }
        /*
        private ValidationResult ValidarIdade(object idade, string displayField) //DateTime DataNascimento)
        {
            /*int AnoBase = DateTime.Today.Year - 18;
            if (DataNascimento.Year < AnoBase)
                return ValidationResult.Success;
            if (AnoBase == DataNascimento.Year)
                if (DataNascimento.Month < DateTime.Now.Month)
                    return ValidationResult.Success;
            if (DataNascimento.Month == DateTime.Now.Month)
                if (DataNascimento.Day <= DateTime.Now.Day)
                    return ValidationResult.Success;
        }*/
        /*
        private ValidationResult ValidaStatus(bool status, ValidationContext validationContext)
        {
            Locacao locacao = (Locacao)validationContext.ObjectInstance;

            if (locacao.AceitaTermo) locacao.Status = "Esperando aprovação";

            if (!locacao.AceitaTermo) locacao.Status = "Negado";

            return ValidationResult.Success;
        }*/
    }
}