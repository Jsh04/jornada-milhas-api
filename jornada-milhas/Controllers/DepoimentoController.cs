
using API_Domains.DTO;
using API_Domains.Interfaces;
using API_Infraestrutura.Indices;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace jornada_milhas.Controllers;

[ApiController]
[Route("[controller]")]
[DisableCors]
public class DepoimentoController : ControllerBase
{

    private readonly IDepoimentosService _depoimentosService;
    private readonly IMapper _mapper;

    public DepoimentoController(IDepoimentosService depoimentosService, IMapper mapper)
    {
        _depoimentosService = depoimentosService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> PegarDepoimentos()
    {
        var dados = await _depoimentosService.GetAllDepoimentosAsync();

       return Ok(dados);
    }

    [HttpPost]
    public async Task<IActionResult> CriarDepoimentos([FromBody] DepoimentoDTO depoimentoDTO)
    {
        var depoimento = _mapper.Map<DepoimentosIndex>(depoimentoDTO);
        var depoimentoCriado = await _depoimentosService.CreateDepoimento(depoimento);

        return Ok(depoimentoCriado);
    }

}
