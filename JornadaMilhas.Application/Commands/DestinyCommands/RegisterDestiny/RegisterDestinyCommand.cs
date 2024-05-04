using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny
{
    public sealed record RegisterDestinyCommand(string Name, string Subtitle, decimal Price, string DescriptionPortuguese, string DescriptionEnglish, List<string> Images) : IRequest<Result<Destiny>>{ }
}
