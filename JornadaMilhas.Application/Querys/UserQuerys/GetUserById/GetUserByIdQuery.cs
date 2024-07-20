using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetUserById;

public record GetUserByIdQuery(long Id) : IRequest<Result<UserDto>>
{}
