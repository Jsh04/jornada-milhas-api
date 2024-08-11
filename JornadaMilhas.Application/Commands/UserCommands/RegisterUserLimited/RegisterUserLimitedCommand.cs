using JornadaMilhas.Common.Results;
using MediatR;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Common.Enums;
using JornadaMilhas.Common.InputDto;

namespace JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;

public sealed record RegisterUserLimitedCommand(
    string Name, 
    DateTime DtBirth,
    EnumGenre Genre,
    string Cpf,
    string Phone,
    AddressInputDto Address,
    string Mail, 
    string ConfirmMail,
    string Password,
    string ConfirmPassword
    ) : IRequest<Result<UserLimited>>
{
}
