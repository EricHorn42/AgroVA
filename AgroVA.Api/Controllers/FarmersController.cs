using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroVA.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FarmersController : BaseController<IFarmerService, FarmerDTO>
{
    public FarmersController(IFarmerService service) : base(service)
    {
    }
}    
