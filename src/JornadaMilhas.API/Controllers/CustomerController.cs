using JornadaMilhas.API.Extensions;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.InputModels;
using JornadaMilhas.Application.Querys.UserQuerys.GetCustomerById;
using JornadaMilhas.Core.Entities.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers;


[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{

    private readonly ISender _mediator;

    public CustomerController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateInputModel customerCreateInputModel,
        CancellationToken cancellationToken = default)
    {
        var command = new RegisterCustomerCommand(customerCreateInputModel);
        
        var result = await _mediator.Send(command, cancellationToken);

        return result.Success
            ? CreatedAtAction(nameof(GetCustomerById), new { id = result.Value.Id }, customerCreateInputModel)
            : result.ToProblemDetails();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetCustomerById(long id, CancellationToken cancellationToken = default)
    {
        var getByIdQuery = new GetCustomerByIdQuery(id);
        
        var result = await _mediator.Send(getByIdQuery, cancellationToken);
        
        return result.Success ? Ok(result) : result.ToProblemDetails();
    }
}