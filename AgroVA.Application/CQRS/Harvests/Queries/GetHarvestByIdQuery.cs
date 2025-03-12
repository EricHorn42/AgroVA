using AgroVA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Harvests.Queries
{
    public class GetHarvestByIdQuery : IRequest<Harvest>
    {
        public int Id { get; set; }

        public GetHarvestByIdQuery(int id)
        {
            Id = id;
        }
    }
}
