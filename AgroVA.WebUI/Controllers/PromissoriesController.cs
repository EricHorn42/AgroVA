﻿using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using AgroVA.Domain.Interfaces;
using AgroVA.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace AgroVA.WebUI.Controllers;

public class PromissoriesController : ControllerBase<IPromissoryService, PromissoryDTO>
{
    private readonly IFarmerRepository _farmerRepository;
    private readonly IHarvestRepository _harvestRepository;

    public PromissoriesController(IPromissoryService service, IFarmerRepository farmerRepository, IHarvestRepository harvestRepository) : base(service)
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
