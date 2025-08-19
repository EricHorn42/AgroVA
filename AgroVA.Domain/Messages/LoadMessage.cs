namespace AgroVA.Domain.Messages;

public static class LoadMessage
{
    public const string InvalidId = "Id inválido";
    public const string InvalidTimestamp = "Data inválida";
    public const string InvalidGreenWeight = "Peso verde inválido";
    public const string InvalidDryWeight = "Peso seco inválido";
    public const string InvalidRegister = "Registro inválido";
    public const string InvalidPrice = "Preço inválido";
    public const string InvalidWholePercent = "Percentual de inteiro inválido";
    public const string InvalidInvoice = "Nota Fiscal inválida";
    public const string MaxLengthGreenWeight = "Peso verde deve ter no máximo 8 caracteres";
    public const string MaxLengthDryWeight = "Peso seco deve ter no máximo 8 caracteres";
    public const string MaxLengthPrice = "Preço deve ter no máximo 10 caracteres";
    public const string MaxLengthWholePercent = "Percentual de inteiro deve ter no máximo 3 caracteres";
    public const string RequiredTimestamp = "Data é obrigatória";
    public const string RequiredRegister = "Registro é obrigatório";
    public const string RequiredInvoice = "Nota Fiscal é obrigatória";
}
