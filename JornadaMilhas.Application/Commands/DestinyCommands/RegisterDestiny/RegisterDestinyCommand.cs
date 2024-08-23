using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using MediatR;

namespace JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny
{
    public sealed record RegisterDestinyCommand(string Name, string Subtitle, decimal Price, string DescriptionPortuguese, string DescriptionEnglish, List<string> Images) : IRequest<Result<Destiny>>{ }
}
