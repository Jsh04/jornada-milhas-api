using JornadaMilhas.Core.Entities;

namespace JornadaMilhas.Application.Querys.Dtos.DestinysDto;

public sealed record DestinyDto(
    long Id,
    string Name,
    decimal Price,
    string DescriptionPortuguese,
    string DescriptionEnglish,
    List<ImagemDestino> Imagens
    )
{
}
