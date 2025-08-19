using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Annotations.Commands;

public abstract class AnnotationCommand : IRequest<Annotation>
{
    public string Observation { get; set; }
    public DateOnly Timestamp { get; set; }
    public int FarmerId { get; set; }
    public int HarvestId { get; set; }
}
