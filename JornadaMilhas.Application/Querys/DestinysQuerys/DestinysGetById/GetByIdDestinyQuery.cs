using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById;

public record GetByIdDestinyQuery(long id) : IRequest<Result<Destiny>>{};



