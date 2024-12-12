using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Commands.FlightCommands.RegisterFlight;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.ValueObjects.Locales;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
public class FlightController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<Locale>))]
    public async Task<IActionResult> CreateFlight([FromBody] RegisterFlightCommand command)
    {
        var resultRegisterDestiny = await _flightService.RegisterDestiny(command);

        return resultRegisterDestiny.Match(
            value => CreatedAtAction(nameof(GetFlightById), new { id = value.Id }, command),
            value => value.ToProblemDetails());
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<FlightsDto>))]
    public async Task<IActionResult> GetAllFlights([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var result = await _flightService.GetAllFlights(page, size);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<FlightsDto>))]
    public async Task<IActionResult> GetFlightById(long id)
    {
        var result = await _flightService.GetFlightById(id);
        return result.Match(Ok, value => value.ToProblemDetails());
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteFlightById(long id)
    {
        var result = await _flightService.DeleteDestinyById(id).ConfigureAwait(false);
        return result.Match(Ok, value => value.ToProblemDetails());
    }
}