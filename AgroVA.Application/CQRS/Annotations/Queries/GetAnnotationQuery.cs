using AgroVA.Domain.Entities;
using MediatR;

namespace AgroVA.Application.CQRS.Annotations.Queries;

public class GetAnnotationQuery : IRequest<IEnumerable<Annotation>>
{

}
