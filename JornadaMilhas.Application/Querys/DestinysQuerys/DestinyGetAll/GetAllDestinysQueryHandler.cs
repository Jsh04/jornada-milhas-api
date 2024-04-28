using JornadaMilhas.Core.Entities.Destinys;
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

    public GetAllDestinysQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Destiny>> Handle(GetAllDestinysQuery request, CancellationToken cancellationToken)
    {
        _unitOfWork.DestinoRepository.GetAll(request.Page, request.Size);
        throw new NotImplementedException();
    }
}
