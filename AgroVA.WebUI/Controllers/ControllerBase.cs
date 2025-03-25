using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroVA.WebUI.Controllers;

[Authorize]
public class ControllerBase<TService, TDto> : Controller
        where TService : IServiceBase<TDto>
        where TDto : DTOBase
{
    protected readonly TService _service;

    public ControllerBase(TService service)
    {
        _service = service;
    }

    [HttpGet]
    public async virtual Task<IActionResult> Index()
    {
        var dtos = await _service.GetAllAsync();
        return View(dtos);
    }

    public async virtual Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var dtos = await _service.GetByIdAsync(id);

        if (dtos == null) return NotFound();

        return View(dtos);
    }

    [HttpGet]
    public async virtual Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async virtual Task<IActionResult> Create(TDto dtos)
    {
        if (ModelState.IsValid)
        {
            await _service.AddAsync(dtos);
            return RedirectToAction(nameof(Index));
        }

        return View(dtos);
    }

    public async virtual Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var dtos = await _service.GetByIdAsync(id);

        if (dtos == null) return NotFound();

        return View(dtos);
    }

    [HttpPost]
    public async virtual Task<IActionResult> Edit(int id, TDto dtos)
    {
        if (id != dtos.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                await _service.UpdateAsync(dtos);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        return View(dtos);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async virtual Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var dtos = await _service.GetByIdAsync(id);

        if (dtos == null) return NotFound();

        return View(dtos);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Admin")]
    public async virtual Task<IActionResult> DeleteConfirmed(int id)
    {
        var dtos = await _service.GetByIdAsync(id);

        if (dtos != null)
            await _service.DeleteAsync(dtos.Id);


        return RedirectToAction(nameof(Index));
    }
}
