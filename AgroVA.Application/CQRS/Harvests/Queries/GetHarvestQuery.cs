using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Harvests.Queries;

public class GetHarvestQuery : IRequest<IEnumerable<Harvest>>
{

}
