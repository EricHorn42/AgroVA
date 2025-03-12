using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Domain.Messages
{
    public static class RentMessage
    {
        public const string InvalidId = "Id inválido";
        public const string InvalidPerson = "Pessoa inválida";
        public const string InvalidPercent = "Percentual inválido";
        public const string InvalidValue = "Valor inválido";
        public const string InvalidAnnotation = "Anotação inválida";
        public const string MaxLengthPerson = "Pessoa deve ter no máximo 200 caracteres";
        public const string MaxLengthPercent = "Percentual deve ter no máximo 3 caracteres";
        public const string MaxLengthValue = "Valor deve ter no máximo 10 caracteres";
        public const string MaxLengthAnnotation = "Anotação deve ter no máximo 500 caracteres";
        public const string RequiredPerson = "Pessoa é obrigatória";
        public const string RequiredPercent = "Percentual é obrigatório";
        public const string RequiredValue = "Valor é obrigatório";        
    }
}
