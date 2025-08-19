using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroVA.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnotationsController : BaseController<IAnnotationService, AnnotationDTO>
{
    public AnnotationsController(IAnnotationService service) : base(service)
    {
    }
}    
