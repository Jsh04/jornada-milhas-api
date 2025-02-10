using JornadaMilhas.Application.Interfaces.UOW;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Events;
using JornadaMilhas.Core.Events.Shareds;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;

public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Result<Customer>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public RegisterCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<Result<Customer>> Handle(RegisterCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var hasUser = await _customerRepository.IsUniqueAsync(request.Cpf, request.Mail, cancellationToken);
        if (hasUser)
            return Result.Fail<Customer>(UserErrors.UserIsNotUnique);

        var userResult = CustomerBuilder
            .Create()
            .WithName(request.Name)
            .WithAddress(
                city: request.Address.City,
                state: request.Address.State, 
                district: request.Address.District, 
                zipCode: request.Address.ZipCode,
                street: request.Address.Address)
            .WithGenre(request.Genre)
            .WithEmail(request.Mail)
            .WithPhone(request.Phone)
            .WithPassword(request.Password)
            .WithDocumentation(request.Cpf)
            .WithConfirmMail(request.ConfirmMail)
            .WithDtOfBirth(request.DtBirth)
            .Build();

        if (!userResult.Success)
            return Result.Fail<Customer>(userResult.Errors);

        var user = userResult.Value;

        await _customerRepository.CreateAsync(user);

        RaiseEventSendEmail(user);

        var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        return !created ? Result.Fail<Customer>(UserErrors.CannotBeCreated) : Result.Ok(user);
    }

    private static void RaiseEventSendEmail(User user)
    {
        var sendEmailEvent = new EmailCreateUserEvent(new UserEvent(user.Name, user.Email.Address, user.DtCreated));

        user.ThrowEvent(sendEmailEvent);
    }
}