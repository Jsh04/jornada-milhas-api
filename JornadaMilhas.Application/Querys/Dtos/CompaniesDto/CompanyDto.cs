using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.Dtos.CompaniesDto
{
    public record CompanyDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
