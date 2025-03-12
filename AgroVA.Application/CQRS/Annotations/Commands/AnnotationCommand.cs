using MediatR;
using AgroVA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Annotations.Commands
{
    public abstract class AnnotationCommand : IRequest<Annotation>
    {
        public string Observation { get; set; }
        public DateTime Timestamp { get; set; }
        public int FarmerId { get; set; }
        public int HarvestId { get; set; }
    }
}
