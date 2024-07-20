using JornadaMilhas.Common.Enums;
using JornadaMilhas.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



