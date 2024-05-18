
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
public class DepoimentController : ControllerBase
{

    private readonly IMediator _mediator;

    public DepoimentController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    
    
        
    


}
