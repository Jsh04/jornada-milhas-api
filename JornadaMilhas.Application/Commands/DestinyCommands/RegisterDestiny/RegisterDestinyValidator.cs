using FluentValidation;

namespace JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;

public sealed class RegisterDestinyValidator : AbstractValidator<RegisterDestinyCommand>
{
    public RegisterDestinyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name é obrigatório");

        RuleFor(x => x.Subtitle)
            .NotNull()
            .NotEmpty()
            .WithMessage("Subtítulo é obrigatório");

        RuleFor(x => x.Price)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Preço é obrigatório");

        RuleFor(x => x.DescriptionPortuguese)
            .NotNull()
            .NotEmpty()
            .WithMessage("Descrição em português é obrigatório");

        RuleFor(x => x.DescriptionEnglish)
            .NotNull()
            .NotEmpty()
            .WithMessage("Descrição em inglês é obrigatório");

        RuleFor(x => x.Images)
            .Must(x => x.Count > 0)
            .WithMessage("Imagens são obrigatórias");
    }
}