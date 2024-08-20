﻿using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.PaginationResult;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetAllUsers
{
    public record GetAllUsersQuery(int Page, int Size) : IRequest<PaginationResult<UserDto>>{}
    
}