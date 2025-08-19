using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Annotations.Queries;

public class GetAnnotationByIdQuery : IRequest<Annotation>
{
    public int Id { get; set; }

    public GetAnnotationByIdQuery(int id)
    {
        Id = id;
    }
}
