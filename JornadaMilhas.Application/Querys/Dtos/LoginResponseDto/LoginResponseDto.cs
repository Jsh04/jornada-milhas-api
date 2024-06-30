using JornadaMilhas.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;

public record LoginResponseDto
{
    public string Token { get; set; }
    public User User { get; set; }

}
