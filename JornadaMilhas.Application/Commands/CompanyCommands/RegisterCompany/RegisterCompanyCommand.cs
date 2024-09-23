using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Application.Querys.Dtos.CompaniesDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.CompanyCommands.RegisterCompany;

public record RegisterCompanyCommand(string Name, string Description, string codeCompany) : IRequest<Result<CompanyDto>>;
    

