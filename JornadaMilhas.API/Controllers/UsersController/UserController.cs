using JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment;
using JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers.UsersController;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] int size = 10, [FromQuery] int page = 1)
    {
        return Ok();
    }
}
