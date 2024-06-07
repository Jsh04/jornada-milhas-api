using JornadaMilhas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
