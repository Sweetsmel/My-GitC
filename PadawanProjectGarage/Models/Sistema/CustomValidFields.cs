using Newtonsoft.Json.Converters;
using PadawanProjectGarage.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

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
                    case ValidFields.ValidaNome:      return ValidarNome(value, validationContext.DisplayName);
                    case ValidFields.ValidaEmail:     return ValidarEmail(value, validationContext.DisplayName);
                    case ValidFields.ValidaPlaca:     return ValidarPLaca(value, validationContext.DisplayName);
                    //case ValidFields.ValidaVigente:   return ValidarVigente(value, validationContext.DisplayName);
                    //case ValidFields.ValidaAprovacao: return ValidarAprovacao(value, validationContext.DisplayName);
                    //case ValidFields.ValidaEspera:    return ValidarEspera(value, validationContext.DisplayName);
                    //case ValidFields.ValidaIdade:
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

        /*private ValidationResult ValidarData(object data, string displayField)
        {
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" };
                GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(dateTimeConverter);

            if (dateTimeConverter)
                return ValidationResult.Success;

            return new ValidationResult($"O campo {displayField} não está no formato aceitável!");

            
        }*/


        /*private ValidationResult ValidarIdade(object idade, string displayField) //DateTime DataNascimento)
        {
            int Idade = DateTime.Today.Year - Colaborador.DataNascimento.Year;
            if (Colaborador.DataNascimento.Date > DateTime.Today.AddYears(-Idade))
            {
                Idade--;
            }
            return (Idade >= 60) ? true : false;
        }*/

        /*private ValidationResult ValidarVigente(bool status, ValidationContext validationContext)
        {
            Locacao locacao = (Locacao)validationContext.ObjectInstance;

            if (locacao.termoDeLocacao) locacao.Status = "Esperando aprovação";

            if (!locacao.AceitaTermo) locacao.Status = "Negado";

            return ValidationResult.Success;
        }*/

        /*private ValidationResult ValidarVeiculos(bool value, ValidationContext validationContext)
        {
            TipoVeiculo tipoVeiculo = (TipoVeiculo)validationContext.ObjectInstance;

            if(tipoVeiculo.CodigoTipo) tipoVeiculo.Descricao = ""
        }*/
    }
}