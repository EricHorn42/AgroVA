using AgroVA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Annotations.Queries;

public class GetAnnotationByIdQuery : IRequest<Annotation>
{
    public int Id { get; set; }

    public GetAnnotationByIdQuery(int id)
    {
        Id = id;
    }
}
