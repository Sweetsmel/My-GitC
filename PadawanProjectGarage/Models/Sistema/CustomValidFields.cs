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
using System.Web.UI.WebControls;

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
                    case ValidFields.ValidaStatus:      return ValidarStatus(validationContext);
                    //case ValidFields.ValidaVigente:   return ValidarVigente(validationContext);
                    //case ValidFields.ValidaAprovacao: return ValidarAprovacao(value, validationContext.DisplayName);
                    //case ValidFields.ValidaEspera:    return ValidarEspera(validationContext);
                    //case ValidFields.ValidaPrioridade: return ValidarPrioridade(value, validationContext.DisplayName)
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
        /*private ValidationResult ValidarPrioridade(ValidationContext validationContext)
        {
            Colaborador colaborador = (Colaborador)validationContext.ObjectInstance;
            if (colaborador.Idoso == true)
                return ValidationContext.Success;
        }*/

        /*private ValidationResult ValidarIdade(object idade, string displayField) //DateTime DataNascimento)
        {
            DateTime dt;
            DateTime dtNascimentoMax = DateTime.Now.AddYears(-60);
            DateTime dtMax = DateTime.Parse("dd/MM/yyyy");

            int Idade = DateTime.Today.Year - UsuarioTipo.DataNascimento.Year;
            if (UsuarioTipo.DataNascimento.Date > DateTime.Today.AddYears(-Idade))
            {
                Idade--;
            }
            return (Idade >= 60) ? true : false;
        }*/
        private ValidationResult ValidarStatus(ValidationContext validationContext)
        {
            Locacao locacao = (Locacao)validationContext.ObjectInstance;

            if (locacao.AceitaTermo)
            {
                locacao.Status = (int)ValidFields.ValidaStatus;
                return ValidationResult.Success;
            }
            return new ValidationResult("Para realizar a locação, você deve aceitar os termos de uso");    //O campo {validationContext.DisplayName} é inválido
        }
        /*private ValidationResult ValidarVigente(ValidationContext validationContext)
        {
            Locacao locacao = (Locacao)validationContext.ObjectInstance;

            if (locacao.AceitaTermo)
            {
                locacao.Status = (int)ValidFields.ValidaEspera;
                return ValidationResult.Success;
            }
            return new ValidationResult("Sua intenção de locação foi realizada com sucesso! Entraremos em contato para confirmar e seguir com as orientações de acesso.");
        }*/
        /*private ValidationResult ValidarAprovacao(ValidationContext validationContext)
        {
            Locacao locacao = (Locacao)validationContext.ObjectInstance;

            if (locacao.AceitaTermo)
            {
                locacao.Status = (int)ValidFields.ValidaEspera;
                return ValidationResult.Success;
            }
            return new ValidationResult($"Sua locação está em aprovação.");
        }*/
    }
}