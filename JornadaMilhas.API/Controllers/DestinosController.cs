using API_Domains.Interfaces.Destinos;
using AutoMapper;
using JornadaMilhas.Core.DTO.Destinos;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
public class DestinosController : ControllerBase
{
    private readonly IDestinosService _destinoService;


    public DestinosController(IDestinosService destinoService)
    {
        _destinoService = destinoService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDestino([FromBody] CreateDestinoDTO destinoDto)
    {
        var destinoCriado = await _destinoService.CreateDestino(destinoDto);
        return Ok(destinoCriado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestino(string id)
    {
        var deleted = await _destinoService.DeleteDestino(id);
        if (deleted)
            return NoContent();
        return BadRequest();
        
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDestino(string id, [FromBody] UpdateDestinoDTO updateDestinoDto)
    {
        var updated = await _destinoService.UpdateDestino(updateDestinoDto, id);
        if (updated)
            return NoContent();
        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDestinyById(string id)
    {
        var destiny = await _destinoService.GetDestinoById(id);
        return Ok(destiny);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllDestinos([FromQuery] int size, [FromQuery] int page) 
    {
        var destinos =  await _destinoService.GetAllAsync(page, size);
        return Ok(destinos);
    }
}
