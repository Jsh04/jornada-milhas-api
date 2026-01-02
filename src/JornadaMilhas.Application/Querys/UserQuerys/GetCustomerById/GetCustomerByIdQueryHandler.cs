using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetCustomerById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<CustomerDto>> Handle(GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var userById = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (userById is null)
            return Result.Fail<CustomerDto>(UserErrors.NotFound);

        var userDtoMapped = DtoExtensions<Customer, CustomerDto>.ToDto(userById);

        return Result.Ok(userDtoMapped);
    }
}