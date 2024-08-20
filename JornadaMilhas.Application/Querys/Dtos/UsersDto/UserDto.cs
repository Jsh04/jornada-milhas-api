using JornadaMilhas.Common.Enums;
using JornadaMilhas.Common.ValueObjects;

namespace JornadaMilhas.Application.Querys.Dtos.UsersDto;

public record UserDto
{
    public string Name { get; set; }

    public DateOfBirth DtBirth { get; set; }

    public EnumGenre Genre { get; set; }

    public Cpf Cpf { get;  set; }

    public Phone Phone { get;  set; }

    public Address Address { get; set; }

    public byte[]? Picture { get;  set; }

    public Email Email { get; set; }

}



