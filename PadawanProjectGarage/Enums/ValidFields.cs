using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PadawanProjectGarage.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ValidFields
    {
        ValidaNome,
        ValidaEmail,
        ValidaPlaca,

        [EnumMember(Value = "Vigente")]
        ValidaVigente = 1,      //ativo
        [EnumMember(Value = "Em aprovação")]
        ValidaAprovacao = 2,    //inativo
        [EnumMember(Value = "Fila de espera")]
        ValidaEspera = 4,       //aguardo

        //ValidaIdade,

    }
}