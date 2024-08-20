
using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment;
using JornadaMilhas.Application.Querys.DepoimentQuerys.GetAllDepoiments;
using JornadaMilhas.Application.Querys.DepoimentQuerys.GetByIdDepoiment;
using JornadaMilhas.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
public class DepoimentController : ControllerBase
{

    private readonly IMediator _mediator;

    public DepoimentController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterDepoiment([FromBody] RegisterDepoimentCommand command)
    {
        var resultDepoiment = await _mediator.Send(command);
        return resultDepoiment.Success
            ? CreatedAtAction(nameof(GetDepoimentById), new { id = resultDepoiment.Value.Id }, resultDepoiment.Value)
            : resultDepoiment.ToProblemDetails();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllDepoiment([FromQuery] GetAllDepoimentQuery query)
    {
        var paginationResult = await _mediator.Send(query);

        return paginationResult.Match(
            Ok, 
            (value) => value.ToProblemDetails());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDepoimentById(long id)
    {
        var resultDepoiment = await _mediator.Send(new GetByIdDepoimentQuery(id));
        return resultDepoiment.Success ? Ok(resultDepoiment.Value) : NotFound(resultDepoiment.Errors);
    }
    
        
    


}
