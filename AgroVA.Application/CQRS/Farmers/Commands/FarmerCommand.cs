using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Farmers.Commands;

public abstract class FarmerCommand : IRequest<Farmer>
{
    public string Observation { get; set; }
    public DateTime Timestamp { get; set; }
    public int FarmerId { get; set; }
    public int HarvestId { get; set; }
}
