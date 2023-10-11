
using API_Domains.DTO;
using API_Domains.Interfaces;
using API_Infraestrutura.Indices;
using Microsoft.AspNetCore.Mvc;

namespace jornada_milhas.Controllers;

[ApiController]
[Route("[controller]")]
public class DepoimentoController : ControllerBase
{

    private readonly IDepoimentosService _depoimentosService;

    public DepoimentoController(IDepoimentosService depoimentosService)
    {
        _depoimentosService = depoimentosService;
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
        var depoimento = new DepoimentosIndex()
        {
            Nome = depoimentoDTO.Nome,
            Foto = depoimentoDTO.Foto,
            DescricaoDepoimento = depoimentoDTO.DescricaoDepoimento

        };
        var depoimentoCriado = await _depoimentosService.CreateDepoimento(depoimento);

        return Ok(depoimentoCriado);
    }
}
