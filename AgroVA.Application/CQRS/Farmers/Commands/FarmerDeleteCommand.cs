using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Farmers.Commands;

public class FarmerDeleteCommand : IRequest<Farmer>
{
    public int Id { get; set; }

    public FarmerDeleteCommand(int id)
    {
        Id = id;
    }
}
