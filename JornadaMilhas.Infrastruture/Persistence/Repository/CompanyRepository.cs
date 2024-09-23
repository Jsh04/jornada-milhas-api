using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private JornadaMilhasDbContext _context;
        public CompanyRepository(JornadaMilhasDbContext context) => _context = context;
        

        public void Create(Company entity)
        {
            _context.Company.Add(entity);
        }

        public async Task<bool> IsUniqueAsync(string codeCompany, CancellationToken cancellationToken = default)
        {
            return await _context.Company.AnyAsync(company => company.CodeCompany == codeCompany, cancellationToken);
        }
    }
}
