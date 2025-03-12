using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Harvests.Commands
{
    public class HarvestUpdateCommand : HarvestCommand
    {
        public int Id { get; set; }
    }
}
