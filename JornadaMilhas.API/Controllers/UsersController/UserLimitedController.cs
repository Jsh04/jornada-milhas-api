using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.GetUserById;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers.UsersController;

[ApiController]
[Route("[controller]")]
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

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    public async Task<IActionResult> GetUserLimitedById(long id)
    {
        var result = await _service.GetUserById(new GetUserByIdQuery(id));

        return result.Match(Ok, value => value.ToProblemDetails());
    }
}
