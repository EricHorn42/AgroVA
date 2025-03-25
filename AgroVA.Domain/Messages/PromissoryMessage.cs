using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Domain.Messages;

public static class PromissoryMessage
{
    public const string InvalidId = "Id inválido";
    public const string InvalidTimestamp = "Data inválida";
    public const string InvalidValue = "Valor inválido";
    public const string RequiredTimestamp = "Data é obrigatória";
    public const string RequiredValue = "Valor é obrigatório";
}
