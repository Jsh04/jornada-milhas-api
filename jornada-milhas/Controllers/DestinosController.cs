using API_Domains.DTO.Destinos;
using API_Domains.Indices;
using API_Domains.Interfaces;
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
    public async Task<IActionResult> CreateDestino([FromBody] DestinoDTO destinoDTO)
    {
        var destino = _mapper.Map<DestinosIndex>(destinoDTO);
        var destinoCriado = await _destinoService.CreateDestino(destino);
        return Ok(destinoCriado);
    }

    [HttpGet]
    public IActionResult GetAllDestinos([FromQuery] int size, [FromQuery] int page) 
    {
        var destinos = _destinoService.GetAllAsync(size, page);
        return Ok(destinos);
    }


}
