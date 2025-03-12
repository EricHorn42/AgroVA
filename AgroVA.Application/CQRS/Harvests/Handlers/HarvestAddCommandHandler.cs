using AgroVA.Application.CQRS.Harvests.Commands;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Application.CQRS.Harvests.Handlers
{
    public class HarvestAddCommandHandler : IRequestHandler<HarvestAddCommand, Harvest>
    {
        private readonly IHarvestRepository _repository;

        public HarvestAddCommandHandler(IHarvestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Harvest> Handle(HarvestAddCommand request, CancellationToken cancellationToken)
        {
            //var annotation = new Harvest();

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
}
