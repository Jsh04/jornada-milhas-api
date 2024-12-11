using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface IDestinyService
{
    Task<Result> DeleteDestinyById(long id);

    Task<Result<DestinyDto>> GetDestinyById(long id);

    Task<PaginationResult<DestinyDto>> GetAllDestinies(int size, int page);

    Task<Result<Locale>> RegisterDestiny(RegisterDestinyCommand command);
}