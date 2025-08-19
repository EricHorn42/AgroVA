using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Harvests.Commands;

public class HarvestDeleteCommand : IRequest<Harvest>
{
    public int Id { get; set; }

    public HarvestDeleteCommand(int id)
    {
        Id = id;
    }
}
