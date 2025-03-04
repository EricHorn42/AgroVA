using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Domain.Messages
{
    public static class LoadMessage
    {
        public const string InvalidId = "Id inválido";
        public const string InvalidTimestamp = "Data inválida";
        public const string InvalidGreenWeight = "Peso verde inválido";
        public const string InvalidDryWeight = "Peso seco inválido";
        public const string InvalidRegister = "Registro inválido";
        public const string InvalidPrice = "Preço inválido";
        public const string InvalidWholePercent = "Percentual inteiro inválido";
        public const string InvalidInvoice = "Fatura inválida";
    }
}
