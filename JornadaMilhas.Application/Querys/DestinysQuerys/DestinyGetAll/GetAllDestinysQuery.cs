using JornadaMilhas.Core.Entities.Destinys;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll
{
    public record GetAllDestinysQuery(int Page = 1, int Size = 10) : IRequest<List<Destiny>>{}
}
