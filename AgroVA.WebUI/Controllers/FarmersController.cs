using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Interfaces;

namespace AgroVA.WebUI.Controllers;

public class FarmersController : ControllerBase<IFarmerService, FarmerDTO>
{
    public FarmersController(IFarmerService service) : base(service)
    {
    }
}
