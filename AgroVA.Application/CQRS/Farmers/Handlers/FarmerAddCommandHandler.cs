using AgroVA.Application.CQRS.Farmers.Commands;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Farmers.Handlers;

public class FarmerAddCommandHandler : IRequestHandler<FarmerAddCommand, Farmer>
{
    private readonly IFarmerRepository _repository;

    public FarmerAddCommandHandler(IFarmerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Farmer> Handle(FarmerAddCommand request, CancellationToken cancellationToken)
    {
        //var annotation = new Farmer(request.Observation, request.Timestamp);

        //if (annotation == null)
        //{
        //    throw new ApplicationException("Error creating entity");
        //}
        //else
        //{
        //    annotation.FarmerId = request.FarmerId;
        //    annotation.HarvestId = request.HarvestId;
        //    return await _repository.AddAsync(annotation);
        //}
        return null;
    }
}
