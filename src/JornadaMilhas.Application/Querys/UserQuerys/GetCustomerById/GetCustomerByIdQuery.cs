using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetCustomerById
;

public record GetCustomerByIdQuery(long Id) : IRequest<Result<CustomerDto>>
{
}