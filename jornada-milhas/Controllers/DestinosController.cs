using API_Domains.DTO.Destinos;
using API_Domains.Indices;
using API_Domains.Interfaces.Destinos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace jornada_milhas.Controllers;

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

    [HttpGet]
    public async Task<IActionResult> GetAllDestinos([FromQuery] int size, [FromQuery] int page) 
    {
        var destinos =  await _destinoService.GetAllAsync(size, page);
        return Ok(destinos);
    }
}
