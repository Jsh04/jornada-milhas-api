using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Authentication.Queries.Login;
using JornadaMilhas.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ISender _sender;

    public LoginController(ISender sender)
    {
        _sender = sender;
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<LoginQueryResult>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> PostLoginCredentials([FromBody] LoginQuery loginQuery, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(loginQuery, cancellationToken);
        return result.Match(Ok, loginResponse => loginResponse.ToProblemDetails());
    }
}