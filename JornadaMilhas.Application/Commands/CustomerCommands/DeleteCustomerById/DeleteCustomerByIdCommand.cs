using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.CustomerCommands.DeleteCustomerById;

public record DeleteCustomerByIdCommand(long Id) : IRequest<Result>
{
}