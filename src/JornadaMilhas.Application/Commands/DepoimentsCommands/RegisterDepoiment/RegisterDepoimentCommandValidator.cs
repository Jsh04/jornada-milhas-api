using FluentValidation;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment;

public class RegisterDepoimentCommandValidator : AbstractValidator<RegisterDepoimentCommand>
{
    public RegisterDepoimentCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome é obrigário");

        RuleFor(x => x.DepoimentDescription)
            .NotEmpty()
            .NotNull()
            .WithMessage("DepoimentDescription é obrigatório")
            .MaximumLength(500)
            .WithMessage("Descrição do depoimento deverá ser menor que 500 characters");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage("UserId is required");

        RuleFor(x => x.Picture)
            .NotEmpty()
            .WithMessage("Picture is required");
    }
}