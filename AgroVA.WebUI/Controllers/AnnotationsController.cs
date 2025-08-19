using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgroVA.WebUI.Controllers;

[Authorize]
public class AnnotationsController : ControllerBase<IAnnotationService, AnnotationDTO>
{
    private readonly IFarmerRepository _farmerRepository;
    private readonly IHarvestRepository _harvestRepository;

    public AnnotationsController(IAnnotationService service, IFarmerRepository farmerRepository, IHarvestRepository harvestRepository) : base(service)
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
}
