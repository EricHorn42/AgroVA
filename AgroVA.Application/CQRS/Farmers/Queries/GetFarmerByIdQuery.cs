using AgroVA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Farmers.Queries;

public class GetFarmerByIdQuery : IRequest<Farmer>
{
    public int Id { get; set; }

    public GetFarmerByIdQuery(int id)
    {
        Id = id;
    }
}
