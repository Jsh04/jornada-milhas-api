using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.InputModels;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Customers;
using MediatR;

namespace JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;

public sealed record RegisterCustomerCommand(CustomerCreateInputModel InputModel) : IRequest<Result<Customer>>
{
}