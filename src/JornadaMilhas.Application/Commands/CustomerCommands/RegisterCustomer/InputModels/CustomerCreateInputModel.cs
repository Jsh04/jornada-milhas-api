using JornadaMilhas.Common.Entity.Users.Enums;

namespace JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.InputModels;

public sealed record CustomerCreateInputModel(string Name,
    DateTime DtBirth,
    EnumGenre Genre,
    string Cpf,
    string Phone,
    AddressInputModel Address,
    string Mail,
    string ConfirmMail,
    string Password,
    string ConfirmPassword)
{
    
}