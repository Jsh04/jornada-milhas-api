using JornadaMilhas.Common.Results;
using MediatR;
using JornadaMilhas.Common.InputDTO;
using JornadaMilhas.Core.Entities.Enums;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;

public sealed record RegisterUserLimitedCommand(
    string Name, 
    DateTime DtBirth,
    EnumGenre Genre,
    EnumRole UserRole,
    string Cpf,
    string Phone,
    AddressInputDTO Address,
    string Mail, 
    string ConfirmMail,
    string Password,
    string ConfirmPassword,
    string CodeEmployee
    ) : IRequest<Result<User>>
{
}
