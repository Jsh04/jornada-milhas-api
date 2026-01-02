using FluentValidation;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Application.Commands.FlightCommands.RegisterFlight;

public class LocaleValidation : AbstractValidator<Locale>
{

    public LocaleValidation()
    {
        RuleFor(x => x.City)
            .NotEmpty()
            .NotNull()
            .WithMessage("Cidade é obrigatória")
            .MinimumLength(3)
            .MaximumLength(50);
        
        RuleFor(x => x.Country)
            .NotEmpty()
            .NotNull()
            .WithMessage("País é obrigatório")
            .MinimumLength(3)
            .MaximumLength(50);
        
    }
    
}