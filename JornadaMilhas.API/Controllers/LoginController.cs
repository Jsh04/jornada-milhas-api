

using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;
using JornadaMilhas.Application.Querys.LoginQuerys.LoginUserQuerys;
using JornadaMilhas.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ISender _sender;

    public LoginController(ISender sender)
    {
        _sender = sender;
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<LoginResponseDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> PostLoginCredentials([FromBody] LoginUserQuery loginQuery)
    {
        var result = await _sender.Send(loginQuery);
        return result.Match(Ok, loginResponse => loginResponse.ToProblemDetails());
        
    }
}
