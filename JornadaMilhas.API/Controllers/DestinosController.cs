
using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
public class DestinosController : ControllerBase
{
    private IMediator _mediator;
    public DestinosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<Destiny>))]
    public async Task<IActionResult> CreateDestino([FromBody] RegisterDestinyCommand command)
    {
        var destinoCriado = await _mediator.Send(command);
        return Ok(destinoCriado);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDestinoById(long id)
    { 
        var destiny = await _mediator.Send(new GetByIdDestinyQuery(id));
        return destiny.Success ? Ok(destiny.Value) : NotFound();
    }

}
