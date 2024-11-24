using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PaginationResult<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<PaginationResult<CustomerDto>> Handle(GetAllCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var usersFromDatabase = await _customerRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        var usersDtoToReturn = DtoExtensions<Customer, CustomerDto>.ToDto(usersFromDatabase.Data);

        var paginationResult = new PaginationResult<CustomerDto>(usersFromDatabase.Page,
            usersFromDatabase.PageSize,
            usersFromDatabase.TotalCount,
            usersFromDatabase.TotalPages,
            usersDtoToReturn.ToList());

        return paginationResult;
    }
}