using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities.Companies;

namespace JornadaMilhas.Core.Repositories.Interfaces
{
    public interface ICompanyRepository : ICreatableRepository<Company>
    {
        Task<bool> IsUniqueAsync(string codeCompany, CancellationToken cancellationToken = default);
    }
}
