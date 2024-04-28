using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById
{
    public class GetByIdDestinyQueryHandler : IRequestHandler<GetByIdDestinyQuery, Result<Destiny>>
    {
        private readonly IUnitOfWork _unitOfWork;    

        public GetByIdDestinyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Destiny>> Handle(GetByIdDestinyQuery request, CancellationToken cancellationToken)
        {
            var destiny = await _unitOfWork.DestinoRepository.GetByIdAsync(request.id, cancellationToken);

            if (destiny is null)
                return Result.Fail<Destiny>(DestinyErrors.NotFound);

            return Result.Ok(destiny);
        }
    }
}
