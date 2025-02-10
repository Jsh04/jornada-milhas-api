using FluentValidation;
using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;

namespace JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;

public class PaidPassageValidator : AbstractValidator<PaidPassageInputModel>
{
    public PaidPassageValidator()
    {
        RuleFor(x => x.TypeSeat)
            .NotNull()
            .NotEmpty()
            .WithMessage("Por favor, insira o tipo de passagerio");
    }
}