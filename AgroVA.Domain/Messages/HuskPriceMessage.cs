namespace AgroVA.Domain.Messages;

public static class HuskPriceMessage
{
    public const string InvalidId = "Id inválido";
    public const string InvalidTimestamp = "Data inválida";
    public const string InvalidPercent = "Percentual inválido";
    public const string InvalidPrice = "Preço inválido";
    public const string MaxLengthPercent = "Percentual deve ter no máximo 3 dígitos";
    public const string MaxlengthPrice = "Preço deve ter no máximo 7 dígitos";
    public const string RequiredTimestamp = "Data é obrigatória";
    public const string RequiredPercent = "Percentual é obrigatório";
    public const string RequiredPrice = "Preço é obrigatório";
}
