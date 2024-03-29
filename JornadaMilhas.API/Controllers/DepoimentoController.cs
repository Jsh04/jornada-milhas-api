﻿
using JornadaMilhas.Core.DTO.Depoimeto;
using JornadaMilhas.Core.Interfaces.Depoimentos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class DepoimentoController : ControllerBase
{

    private readonly IDepoimentosService _depoimentosService;

    public DepoimentoController(IDepoimentosService depoimentosService)
    {
        _depoimentosService = depoimentosService;
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> PegarDepoimentoPorId(long id)
    {
        var depoimento = await _depoimentosService.GetDepoimentoById(id);
        return Ok(depoimento);
    }

    [HttpGet]
    public async Task<IActionResult> PegarDepoimentos([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var depoimentos = await _depoimentosService.GetAllDepoimentosAsync(page, size);

       return Ok(depoimentos);
    }

    [HttpPost]
    public async Task<IActionResult> CriarDepoimentos([FromBody] DepoimentoDTO depoimentoDTO)
    {
       
        var depoimentoCriado = await _depoimentosService.CreateDepoimento(depoimentoDTO);

        return CreatedAtAction(nameof(PegarDepoimentoPorId), new { id = depoimentoCriado.Id }, depoimentoCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarDepoimento([FromBody] DepoimentoAtualizarDTO atualizarDTO, long id)
    {
        try
        {
            var depoimentoAtualizado = await _depoimentosService.UpdateDepoimento(atualizarDTO, id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarDepoimento(long id)
    {
        var isDeleted = await _depoimentosService.DeleteDepoimento(id);
        if (isDeleted)
            return NoContent();
        else
            return BadRequest();
    }
}
