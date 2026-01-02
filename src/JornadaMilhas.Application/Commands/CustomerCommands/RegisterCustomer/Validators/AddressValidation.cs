using FluentValidation;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.InputModels;

namespace JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.Validators;

public class AddressValidation : AbstractValidator<AddressInputModel>
{
    public AddressValidation()
    {
        RuleFor(r => r.City)
            .MinimumLength(5).WithMessage("City must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("City must have a maximum of 50 characters");

        RuleFor(r => r.State)
            .MinimumLength(2).WithMessage("State must have a minimum of 2 characters")
            .MaximumLength(50).WithMessage("State must have a maximum of 50 characters");
    }
}