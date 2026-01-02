using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Application.Querys.Dtos.DestinysDto;

public sealed record FlightsDto(
    long Id,
    string Name,
    Locale Locale,
    string DescriptionPortuguese,
    string DescriptionEnglish,
    List<Picture> Imagens
)
{
}