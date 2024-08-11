using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll;

public class GetAllDestinysQueryHandler : IRequestHandler<GetAllDestinysQuery, List<Destiny>> {

    private readonly IUnitOfWork _unitOfWork;

    private readonly IRepositoryDestino _destinyRepository;

    public GetAllDestinysQueryHandler(IUnitOfWork unitOfWork, IRepositoryDestino destinyRepository)
    {
        _unitOfWork = unitOfWork;
        _destinyRepository = destinyRepository;
    }

    public async Task<List<Destiny>> Handle(GetAllDestinysQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
