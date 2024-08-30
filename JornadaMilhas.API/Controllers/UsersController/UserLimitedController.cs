using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetUserById;
using JornadaMilhas.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers.UsersController;

[ApiController]
[Route("ApiV1/[controller]")]
public class UserLimitedController : ControllerBase
{
    private readonly IUserLimitedService _service;

    public UserLimitedController(IUserLimitedService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterUserLimited([FromBody] RegisterUserLimitedCommand command) 
    {
        var resultRegister =  await _service.RegisterUserLimited(command);

        return resultRegister.Match((value) => CreatedAtAction(nameof(GetUserLimitedById), new { id = value.Id }, command), 
            value => value.ToProblemDetails());
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllUsersLimited([FromQuery] int size, [FromQuery] int page)
    {
        var resultRegister = await _service.GetAllUsersAsync(size, page);

        return Ok(resultRegister);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType( StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserLimitedById(long id)
    {
        var result = await _service.GetUserById(new GetUserLimitedByIdQuery(id));

        return result.Match(Ok, value => value.ToProblemDetails());
    }
}
