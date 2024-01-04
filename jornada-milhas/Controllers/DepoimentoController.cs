
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
    public async Task<IActionResult> PegarDepoimentos([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var dados = await _depoimentosService.GetAllDepoimentosAsync(page, size);

       return Ok(dados);
    }

    [HttpPost]
    public async Task<IActionResult> CriarDepoimentos([FromBody] DepoimentoDTO depoimentoDTO)
    {
        var depoimento = _mapper.Map<DepoimentosIndex>(depoimentoDTO);
        var depoimentoCriado = await _depoimentosService.CreateDepoimento(depoimento);

        return Ok(depoimentoCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarDepoimento([FromBody] DepoimentoAtualizarDTO atualizarDTO, string id)
    {
        var depoimento = await _depoimentosService.GetDepoimentoById(id);
        var depoimentorRequisicao = _mapper.Map(atualizarDTO, depoimento);
        var depoimentoAtualizado = await _depoimentosService.UpdateDepoimento(depoimentorRequisicao, id);
        if (depoimentoAtualizado == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarDepoimento(string id)
    {
        var isDeleted = await _depoimentosService.DeleteDepoimento(id);
        if (isDeleted)
            return NoContent();
        else
            return BadRequest();
    }


}
