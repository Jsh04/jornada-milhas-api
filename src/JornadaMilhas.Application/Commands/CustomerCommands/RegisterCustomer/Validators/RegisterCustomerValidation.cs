using FluentValidation;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.InputModels;

namespace JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.Validators;

public class RegisterCustomerValidation : AbstractValidator<CustomerCreateInputModel>
{
    public RegisterCustomerValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome é obrigatório")
            .MinimumLength(3)
            .WithMessage("Name deve ter no mínimo 3 caracteres");

        RuleFor(x => x.Address)
            .SetValidator(new AddressValidation());

        RuleFor(x => x.Mail)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email é obrigatório");

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Senha é obrigatório");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Senha não estão iguais");
    }
}