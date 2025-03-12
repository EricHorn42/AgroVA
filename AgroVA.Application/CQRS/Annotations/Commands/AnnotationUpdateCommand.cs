using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Annotations.Commands
{
    public class AnnotationUpdateCommand : AnnotationCommand
    {
        public int Id { get; set; }
    }
}
