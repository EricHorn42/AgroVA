namespace AgroVA.Application.CQRS.Harvests.Commands;

public class HarvestUpdateCommand : HarvestCommand
{
    public int Id { get; set; }
}
