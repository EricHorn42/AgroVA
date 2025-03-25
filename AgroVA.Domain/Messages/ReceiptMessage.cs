using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Domain.Messages;

public static class ReceiptMessage
{
    public const string InvalidId = "Id inválido";
    public const string InvalidTimestamp = "Data inválida";
    public const string InvalidValue = "Valor inválido";
    public const string InvalidAnnotation = "Anotação inválida";
    public const string RequiredTimestamp = "Data é obrigatória";
    public const string RequiredValue = "Valor é obrigatório";
    public const string RequiredAnnotation = "Anotação é obrigatória";
}
