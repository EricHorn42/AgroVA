using AgroVA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Annotations.Commands;

public class AnnotationDeleteCommand : IRequest<Annotation>
{
    public int Id { get; set; }

    public AnnotationDeleteCommand(int id)
    {
        Id = id;
    }
}
