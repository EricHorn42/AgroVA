using AgroVA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Harvests.Commands;

public class HarvestDeleteCommand : IRequest<Harvest>
{
    public int Id { get; set; }

    public HarvestDeleteCommand(int id)
    {
        Id = id;
    }
}
