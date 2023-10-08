using API_Configuracao.Configuracao;
using API_Domains.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jornada_milhas.Controllers;

[ApiController]
[Route("[controller]")]
public class DepoimentoController : ControllerBase
{


    [HttpGet]
    public IActionResult PegarDepoimentos()
    {
        

        return Ok("conectou");
    }
}
