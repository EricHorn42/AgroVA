namespace AgroVA.Application.CQRS.Farmers.Commands;

public class FarmerUpdateCommand : FarmerCommand
{
    public int Id { get; set; }
}
