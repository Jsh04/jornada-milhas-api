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
    private readonly IMapper _mapper;

    public DestinosController(IDestinosService destinoService, IMapper mapper)
    {
        _destinoService = destinoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDestino([FromBody] CreateDestinoDTO destinoDTO)
    {
        var destino = _mapper.Map<DestinosIndex>(destinoDTO);
        var destinoCriado = await _destinoService.CreateDestino(destino);
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
    public IActionResult GetAllDestinos([FromQuery] int size, [FromQuery] int page) 
    {
        var destinos = _destinoService.GetAllAsync(size, page);
        return Ok(destinos);
    }
}
