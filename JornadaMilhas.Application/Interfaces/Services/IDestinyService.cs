using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Interfaces.Services
{
    public interface IDestinyService
    {
        Task<Result> DeleteDestinyById(long id);

        Task<Result<DestinyDto>> GetDestinyById(long id);

        Task<Result<Destiny>> RegisterDestiny(RegisterDestinyCommand command);
    }
}
