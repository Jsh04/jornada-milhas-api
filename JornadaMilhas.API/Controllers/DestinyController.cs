
using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll;
using JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;


[ApiController]
[Route("[controller]")]
public class DestinyController : ControllerBase
{

    private readonly IDestinyService _destinyService;

    public DestinyController(IDestinyService destinyService)
    {
        _destinyService = destinyService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<Destiny>))]
    public async Task<IActionResult> CreateDestino([FromBody] RegisterDestinyCommand command)
    {
        var resultRegisterDestiny = await _destinyService.RegisterDestiny(command);

        return resultRegisterDestiny.Match((value) => CreatedAtAction(nameof(GetDestinoById), new { id = value.Id }, command),
            value => value.ToProblemDetails());
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<DestinyDto>))]
    public async Task<IActionResult> GetAllDestinies([FromQuery] int page = 1, int size = 10)
    {
        var result = await _destinyService.GetAllDestinies(page, size);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<DestinyDto>))]
    public async Task<IActionResult> GetDestinoById(long id)
    { 
        var result = await _destinyService.GetDestinyById(id);
        return result.Match(Ok, value => value.ToProblemDetails());
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteDestinyById(long id)
    {
        var result = await _destinyService.DeleteDestinyById(id).ConfigureAwait(false);
        return result.Match(Ok, value => value.ToProblemDetails());
    }

}
