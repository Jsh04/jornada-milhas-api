using JornadaMilhas.Application.Commands.DestinyCommands.DeleteDestiny;
using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll;
using JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities.Destinies;

namespace JornadaMilhas.Application.Services
{
    public class DestinyService : IDestinyService
    {
        private readonly ISender _sender;

        public DestinyService(ISender sender)
        {
            _sender = sender;
        }

        public async Task<Result> DeleteDestinyById(long id) 
        {
            var deleteDestinyCommand = new DeleteDestinyCommand(id);
            return await _sender.Send(deleteDestinyCommand);
        }

        public async Task<PaginationResult<DestinyDto>> GetAllDestinies(int size, int page)
        {
            var getAllDestiniesQuery = new GetAllDestinysQuery(page, size);
            return await _sender.Send(getAllDestiniesQuery);
        }

        public async Task<Result<DestinyDto>> GetDestinyById(long id)
        {
            var getDestinyById = new GetByIdDestinyQuery(id);
            return await _sender.Send(getDestinyById);
        }

        public async Task<Result<Destiny>> RegisterDestiny(RegisterDestinyCommand command) => await _sender.Send(command);
    }
}
