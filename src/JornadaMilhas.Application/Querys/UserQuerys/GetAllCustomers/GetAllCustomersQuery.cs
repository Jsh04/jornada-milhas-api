using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.PaginationResult;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetAllCustomers;

public record GetAllCustomersQuery(int Page, int Size) : IRequest<PaginationResult<CustomerDto>>
{
}