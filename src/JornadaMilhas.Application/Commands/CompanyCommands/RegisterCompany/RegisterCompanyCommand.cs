using JornadaMilhas.Application.Querys.Dtos.CompaniesDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.CompanyCommands.RegisterCompany;

public record RegisterCompanyCommand(string Name, string OriginCountry, DateTime DtFoundation)
    : IRequest<Result<CompanyDto>>;