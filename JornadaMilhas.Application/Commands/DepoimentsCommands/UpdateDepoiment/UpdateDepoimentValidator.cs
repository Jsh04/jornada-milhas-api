using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.UpdateDepoiment
{
    public sealed class UpdateDepoimentValidator : AbstractValidator<UpdateDepoimentCommand>
    {
        public UpdateDepoimentValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigário ");

            RuleFor(x => x.DepoimentDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("DepoimentDescription is required")
                .MaximumLength(500)
                .WithMessage("Descrição do depoimento deverá ser menor que 500 characters");
                
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId is required");

            RuleFor(x => x.Picture)
                .NotEmpty()
                .WithMessage("Picture is required");
        }   
    }
}
