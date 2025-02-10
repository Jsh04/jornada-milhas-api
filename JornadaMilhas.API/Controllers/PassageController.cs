using System.Security.Claims;
using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PassageController : ControllerBase
{
    private readonly IPassageService _passageService;
    
    private readonly IUserService _userService;

    public PassageController(IPassageService passageService, IUserService userService)
    {
        _passageService = passageService;
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostPayPassages([FromBody] List<PaidPassageInputModel> passageInputModels)
    {
        var resultCustomerId = _userService.GetCustomerId();
        
        if (!resultCustomerId.Success)
            return resultCustomerId.ToProblemDetails();
        
        var serviceResult = await _passageService.PayPassagesAsync(resultCustomerId.Value, passageInputModels);
        
        return serviceResult.Match(Ok, result => result.ToProblemDetails());
    }
}