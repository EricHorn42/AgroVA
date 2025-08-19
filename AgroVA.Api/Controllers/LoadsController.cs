using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroVA.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoadsController : BaseController<ILoadService, LoadDTO>
{
    public LoadsController(ILoadService service) : base(service)
    {
    }
}
