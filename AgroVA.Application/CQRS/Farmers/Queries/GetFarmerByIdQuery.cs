using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Farmers.Queries;

public class GetFarmerByIdQuery : IRequest<Farmer>
{
    public int Id { get; set; }

    public GetFarmerByIdQuery(int id)
    {
        Id = id;
    }
}
