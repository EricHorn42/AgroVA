using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;

namespace AgroVA.WebUI.Controllers;

public class HarvestsController : ControllerBase<IHarvestService, HarvestDTO>
{
    public HarvestsController(IHarvestService service) : base(service)
    {
    }
}
