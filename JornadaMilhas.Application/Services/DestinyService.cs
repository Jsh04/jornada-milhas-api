using JornadaMilhas.Application.Commands.DestinyCommands.DeleteDestiny;
using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Result<DestinyDto>> GetDestinyById(long id)
        {
            var getDestinyById = new GetByIdDestinyQuery(id);
            return await _sender.Send(getDestinyById);
        }

        public async Task<Result<Destiny>> RegisterDestiny(RegisterDestinyCommand command) => await _sender.Send(command);
    }
}
