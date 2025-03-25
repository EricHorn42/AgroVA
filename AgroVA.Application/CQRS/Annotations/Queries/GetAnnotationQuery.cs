using AgroVA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Annotations.Queries;

public class GetAnnotationQuery : IRequest<IEnumerable<Annotation>>
{

}
