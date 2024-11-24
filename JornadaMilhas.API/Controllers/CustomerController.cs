using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.GetCustomerById;
using JornadaMilhas.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterUserLimited([FromBody] RegisterCustomerCommand command)
    {
        var resultRegister = await _service.RegisterCustomer(command);

        return resultRegister.Match(
            value => CreatedAtAction(nameof(GetUserById), new { id = value.Id }, command),
            value => value.ToProblemDetails());
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllUsers([FromQuery] int size, [FromQuery] int page)
    {
        var resultRegister = await _service.GetAllCustomersAsync(size, page);

        return Ok(resultRegister);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserById(long id)
    {
        var result = await _service.GetCustomerById(new GetCustomerByIdQuery(id));

        return result.Match(Ok, value => value.ToProblemDetails());
    }
}