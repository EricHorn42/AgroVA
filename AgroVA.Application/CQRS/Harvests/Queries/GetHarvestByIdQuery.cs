using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Harvests.Queries;

public class GetHarvestByIdQuery : IRequest<Harvest>
{
    public int Id { get; set; }

    public GetHarvestByIdQuery(int id)
    {
        Id = id;
    }
}
