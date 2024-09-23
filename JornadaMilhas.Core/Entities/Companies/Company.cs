using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Entities.Companies
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }

        public string  Description { get; private set; }

        public string  CodeCompany { get; set; }

        private Company(string name, string description, string codeCompany)
        {
            Name = name;
            Description = description;
            CodeCompany = codeCompany;
        }

        public static Result<Company> Create(string name, string description, string codeCompany)
        {
            var company = new Company(name, description, codeCompany);

            return Result.Ok(company);
        }
    }
}
