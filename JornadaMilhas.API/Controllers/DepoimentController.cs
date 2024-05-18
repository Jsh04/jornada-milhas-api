
using JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
public class DepoimentController : ControllerBase
{

    private readonly IMediator _mediator;

    public DepoimentController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAllDepoiment([FromQuery] GetAllDestinysQuery query)
    {
        _mediator.Send(query);
        return Ok();
    }
    
        
    


}
