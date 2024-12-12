using JornadaMilhas.Core.Entities;

namespace JornadaMilhas.Application.Querys.Dtos.DestinysDto;

public sealed record FlightsDto(
    long Id,
    string Name,
    decimal Price,
    string DescriptionPortuguese,
    string DescriptionEnglish,
    List<Picture> Imagens
)
{
}