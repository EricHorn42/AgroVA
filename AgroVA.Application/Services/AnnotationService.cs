using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Interfaces;
using AgroVA.Domain.Entities;
using AutoMapper;

namespace AgroVA.Application.Services
{
    public class AnnotationService : ServiceBase<AnnotationDTO, Annotation, IAnnotationRepository>, IAnnotationService
    {
        public AnnotationService(IAnnotationRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
