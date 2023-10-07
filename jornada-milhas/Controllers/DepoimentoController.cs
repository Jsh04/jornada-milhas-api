using API_Domains.Interfaces;
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
        var dados = await _depoimentosService.GetAllAsync();
        return Ok(dados);
    }
}
