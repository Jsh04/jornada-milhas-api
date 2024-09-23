using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JornadaMilhas.Core.Entities.Companies;

namespace JornadaMilhas.Application.Commands.CompanyCommands.RegisterCompany
{
    public class RegisterCompanyCommandValidator : AbstractValidator<RegisterCompanyCommand>
    {
        public RegisterCompanyCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Não é permitido nome vazio ou nulo")
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("O nome deverá está entre 3 a 50 caracteres");
        }
    }
}
