using JornadaMilhas.Common.Entity.Users.Enums;
using JornadaMilhas.Common.InputModels;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Customers;
using MediatR;

namespace JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;

public sealed record RegisterCustomerCommand(
    string Name,
    DateTime DtBirth,
    EnumGenre Genre,
    string Cpf,
    string Phone,
    AddressInputModel Address,
    string Mail,
    string ConfirmMail,
    string Password,
    string ConfirmPassword
) : IRequest<Result<Customer>>
{
}