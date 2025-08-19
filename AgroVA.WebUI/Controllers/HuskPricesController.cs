using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgroVA.WebUI.Controllers;

public class HuskPricesController : ControllerBase<IHuskPriceService, HuskPriceDTO>
{
    private readonly IFarmerRepository _farmerRepository;
    private readonly IHarvestRepository _harvestRepository;

    public HuskPricesController(IHuskPriceService service, IFarmerRepository farmerRepository, IHarvestRepository harvestRepository) : base(service)
    {
        _farmerRepository = farmerRepository;
        _harvestRepository = harvestRepository;
    }

    [HttpGet]
    public override async Task<IActionResult> Create()
    {
        ViewData["FarmerId"] = new SelectList(await _farmerRepository.GetAllAsync(), "Id", "Name");
        ViewData["HarvestId"] = new SelectList(await _harvestRepository.GetAllAsync(), "Id", "Year");
        return View();
    }

    [HttpPost]
    public async override Task<IActionResult> Create(HuskPriceDTO dtos)
    {
        dtos.Percent = dtos.Percent / 100;

        return await base.Create(dtos);
    }
}
