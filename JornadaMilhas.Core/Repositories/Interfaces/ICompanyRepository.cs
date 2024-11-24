using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities.Companies;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface ICompanyRepository : ICreatableRepository<Company>
{
    Task<bool> IsUniqueAsync(string name, CancellationToken cancellationToken = default);
}