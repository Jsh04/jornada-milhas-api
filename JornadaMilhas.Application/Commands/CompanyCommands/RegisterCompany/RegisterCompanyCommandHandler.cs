using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Application.Querys.Dtos.CompaniesDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.CompanyCommands.RegisterCompany
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand, Result<CompanyDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CompanyDto>> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken)
        {
            var alreadyExistsCompany = await _companyRepository.IsUniqueAsync(request.codeCompany, cancellationToken);

            if (alreadyExistsCompany)
                return Result.Fail<CompanyDto>(CompanyErrors.CompanyAlreadyExistsInDatabase);

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var companyResult = Company.Create(request.Name, request.Description, request.codeCompany);

            var company = companyResult.Value;

            _companyRepository.Create(company);

            var isCreated = await _unitOfWork.CompleteAsync(cancellationToken) > 0;
            if (!isCreated)
                return Result.Fail<CompanyDto>(CompanyErrors.CompanyCannotBeCreated);
            
            var companyCreated = DtoExtensions<Company, CompanyDto>.ToDto(company);

            return Result.Ok(companyCreated);
        }
    }
}
