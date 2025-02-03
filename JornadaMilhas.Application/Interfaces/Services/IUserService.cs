using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface IUserService
{
    Result<long> GetCustomerId();
}