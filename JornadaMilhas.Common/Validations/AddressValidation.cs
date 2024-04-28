using FluentValidation;
using JornadaMilhas.Common.InputDTO;


namespace JornadaMilhas.Common.Validations;

public class AddressValidation : AbstractValidator<AddressInputDTO>
{
    public AddressValidation()
    {
        RuleFor(x => x.Address)
            .MinimumLength(5).WithMessage("Street must have a minimum of 5 characters")
            .MaximumLength(100).WithMessage("Street must have a maximum of 100 characters");
        
        RuleFor(r => r.City)
            .MinimumLength(5).WithMessage("City must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("City must have a maximum of 50 characters");

        RuleFor(r => r.State)
            .MinimumLength(5).WithMessage("State must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("State must have a maximum of 50 characters");
        
        RuleFor(r => r.ZipCode)
            .MinimumLength(8).WithMessage("ZipCode must have a minimum of 8 characters")
            .MaximumLength(9).WithMessage("ZipCode must have a maximum of 9 characters");

        RuleFor(x => x.District)
            .MinimumLength(3).WithMessage("Bairro deverá ser maior que 3 caracteres")
            .MaximumLength(100).WithMessage("Bairro deverá ser menor que 100 caracteres");
    }
}
