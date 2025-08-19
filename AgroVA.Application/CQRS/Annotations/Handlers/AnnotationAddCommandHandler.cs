using AgroVA.Application.CQRS.Annotations.Commands;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Interfaces;
using MediatR;

namespace AgroVA.Application.CQRS.Annotations.Handlers;

public class AnnotationAddCommandHandler : IRequestHandler<AnnotationAddCommand, Annotation>
{
    private readonly IAnnotationRepository _repository;

    public AnnotationAddCommandHandler(IAnnotationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Annotation> Handle(AnnotationAddCommand request, CancellationToken cancellationToken)
    {
        var annotation = new Annotation(request.Observation, request.Timestamp);

        if (annotation == null)
        {
            throw new ApplicationException("Error creating entity");
        }
        else
        {
            annotation.FarmerId = request.FarmerId;
            annotation.HarvestId = request.HarvestId;
            return await _repository.AddAsync(annotation);
        }
    }
}
