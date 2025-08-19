using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Annotations.Commands;

public class AnnotationDeleteCommand : IRequest<Annotation>
{
    public int Id { get; set; }

    public AnnotationDeleteCommand(int id)
    {
        Id = id;
    }
}
