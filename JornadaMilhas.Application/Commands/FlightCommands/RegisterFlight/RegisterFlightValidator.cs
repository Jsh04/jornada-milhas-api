using FluentValidation;

namespace JornadaMilhas.Application.Commands.FlightCommands.RegisterFlight;

public sealed class RegisterFlightValidator : AbstractValidator<RegisterFlightCommand>
{
    public RegisterFlightValidator()
    {
        RuleFor(x => x.DepartureDate)
            .NotNull()
            .NotEqual(DateTime.MinValue)
            .NotEqual(DateTime.MaxValue)
            .WithMessage("Date de partida obrigatória")
            .LessThan(DateTime.Now.AddHours(3))
            .WithMessage("Horário de partida deve ser, pelo menos, daqui a 3 horas");

        RuleFor(x => x.PlaneId)
            .NotEmpty()
            .NotEmpty()
            .WithMessage("Avião do voo é obrigatório");
        
        RuleFor(x => x.Source)
            .NotNull()
            .NotEmpty()
            .WithMessage("Local de partida obrigatória");

        RuleFor(x => x.Destiny)
            .NotNull()
            .NotEmpty()
            .WithMessage("Local de destino obrigatório");

        RuleFor(x => x.LandingDate)
            .NotNull()
            .NotEmpty()
            .WithMessage("Date de chegada obrigatória");
        
        RuleFor(x => x.Images)
            .Must(x => x.Count > 0)
            .WithMessage("Imagens são obrigatórias");
    }
}