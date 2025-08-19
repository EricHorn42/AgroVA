using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Farmers.Queries;

public class GetFarmerQuery : IRequest<IEnumerable<Farmer>>
{

}
