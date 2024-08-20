using JornadaMilhas.Application.Querys.UserQuerys.GetAllUsers;
using JornadaMilhas.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers.UsersController;

[Route("/ApiV1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQuery query)
    {
        var paginationResult = await _service.GetAllUsersAsync(query.Size, query.Page);
        return Ok(paginationResult);
    }


}
