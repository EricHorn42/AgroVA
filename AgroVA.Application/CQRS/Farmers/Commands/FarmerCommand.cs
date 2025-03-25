using MediatR;
using AgroVA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Farmers.Commands;

public abstract class FarmerCommand : IRequest<Farmer>
{
    public string Observation { get; set; }
    public DateTime Timestamp { get; set; }
    public int FarmerId { get; set; }
    public int HarvestId { get; set; }
}
