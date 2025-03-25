using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Domain.Messages;

public static class FarmerMessage
{
    public const string InvalidId = "Id inválido.";
    public const string InvalidName = "Nome inválido.";
    public const string InvalidPhone = "Telefone inválido.";
    public const string MaxLengthName = "Nome inválido. Muito longo.";
    public const string ShortPhone = "Telefone inválido. Muito curto.";
    public const string LongPhone = "Telefone inválido. Muito longo.";
    public const string RequiredName = "Nome é obrigatório.";
    public const string RequiredPhone = "Telefone é obrigatório.";
}
