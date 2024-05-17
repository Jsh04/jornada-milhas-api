using FluentValidation;
using JornadaMilhas.Common.InputDTO;


namespace JornadaMilhas.Common.Validations;

public class AddressValidation : AbstractValidator<AddressInputDTO>
{
    public AddressValidation()
    {

       
        RuleFor(r => r.City)
            .MinimumLength(5).WithMessage("City must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("City must have a maximum of 50 characters");

        RuleFor(r => r.State)
            .MinimumLength(5).WithMessage("State must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("State must have a maximum of 50 characters");
        
    }
}
