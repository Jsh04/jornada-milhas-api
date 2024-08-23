using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll;

public class GetAllDestinysQueryHandler : IRequestHandler<GetAllDestinysQuery, List<Destiny>> {

    private readonly IRepositoryDestino _destinyRepository;

    public GetAllDestinysQueryHandler(IRepositoryDestino destinyRepository)
    {
        _destinyRepository = destinyRepository;
    }

    public async Task<List<Destiny>> Handle(GetAllDestinysQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
