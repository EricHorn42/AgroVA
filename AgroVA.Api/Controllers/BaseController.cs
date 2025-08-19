using AgroVA.Application.DTOs;
using AgroVA.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgroVA.Api.Controllers;

[Authorize]
public class BaseController<TService, TDto> : ControllerBase
    where TService : IServiceBase<TDto>
    where TDto : DTOBase
{
    protected readonly TService _service;

    public BaseController(TService service)
    {
        _service = service;
    }

    [HttpGet]
    public async virtual Task<ActionResult<IEnumerable<TDto>>> Get()
    {
        var dtos = await _service.GetAllAsync();
        if (dtos == null) return NotFound();

        return Ok(dtos);
    }

    [HttpGet("{id:int}", Name = "[controller]_Get")]
    public async virtual Task<ActionResult<TDto>> Get(int id)
    {
        var dtos = await _service.GetByIdAsync(id);

        if (dtos == null) return NotFound();

        return Ok(dtos);
    }

    [HttpPost]
    public async virtual Task<ActionResult> Post([FromBody] TDto dto)
    {
        if (dto == null) return BadRequest("Invalid Data");

        await _service.AddAsync(dto);

        return CreatedAtRoute($"{ControllerContext.ActionDescriptor.ControllerName}_Get", new { id = dto.Id }, dto);
    }

    [HttpPut("{id:int}")]
    public async virtual Task<ActionResult> Put(int id, [FromBody] TDto dto)
    {
        if (dto == null) return BadRequest();

        if (id != dto.Id) return BadRequest();

        await _service.UpdateAsync(dto);

        return Ok(dto);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async virtual Task<ActionResult<TDto>> Delete(int id)
    {
        var dtos = await _service.GetByIdAsync(id);

        if (dtos == null) return NotFound();

        await _service.DeleteAsync(id);

        return Ok(dtos);
    }
}
