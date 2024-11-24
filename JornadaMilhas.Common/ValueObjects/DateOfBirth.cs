using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Common.ValueObjects;

public sealed record DateOfBirth
{
    public DateOfBirth()
    {
    }

    private DateOfBirth(DateTime dateOfBirth)
    {
        Date = dateOfBirth;
    }

    public DateTime Date { get; }

    public static Result<DateOfBirth> Create(DateTime? dateOfBirth)
    {
        if (dateOfBirth is null)
            return Result.Fail<DateOfBirth>(DateOfBirthErrors.DateOfBirthIsNulll);

        if (!ValidateDtOfBirth(dateOfBirth.Value))
            return Result.Fail<DateOfBirth>(DateOfBirthErrors.DateOfBirthUnder18);

        var dateValidated = new DateOfBirth(dateOfBirth.Value);

        return Result<DateOfBirth>.Ok(dateValidated);
    }

    private static bool ValidateDtOfBirth(DateTime dateOfBirth)
    {
        var dateNow = DateTime.Today;
        var age = dateNow.Year - dateOfBirth.Year;

        if (dateOfBirth.Date > dateNow.AddYears(-age))
            age--;

        return age >= 18;
    }
}

public sealed record DateOfBirthErrors(string Code, string Message, ErrorType Type) : IError
{
    public static Error DateOfBirthInvalid => new("DateOfBirth.DateOfBirthInvalid", "Date de nascimento inválida",
        ErrorType.Validation);

    public static Error DateOfBirthIsNulll => new("DateOfBirth.DateOfBirthIsNulll", "Data de nascimento é nula",
        ErrorType.Validation);

    public static Error DateOfBirthUnder18 => new("DateOfBirth.DateOfBirthUnder18",
        "Data de nascimento informado menor que 18 anos",
        ErrorType.Validation);
}