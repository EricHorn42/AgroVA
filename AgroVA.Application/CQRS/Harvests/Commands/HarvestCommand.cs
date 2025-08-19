using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Harvests.Commands;

public abstract class HarvestCommand : IRequest<Harvest>
{
    public string Observation { get; set; }
    public DateTime Timestamp { get; set; }
    public int FarmerId { get; set; }
    public int HarvestId { get; set; }
}
