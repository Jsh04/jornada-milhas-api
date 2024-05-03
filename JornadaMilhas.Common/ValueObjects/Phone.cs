using System.Text.RegularExpressions;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Common.ValueObjects;

public class Phone
{
    public string Number { get; }
    
    private const string _pattern = @"^[0-9]{10,11}$";
    
    private Phone()
    { }

    private Phone(string number)
    {
        Number = number;
    }
    
    public static Result<Phone> Create(string number)
    {
        number = FormatFields(number);
        
        if (string.IsNullOrEmpty(number))
            return Result.Fail<Phone>(PhoneErrors.PhoneIsRequired);

        if (!IsValid(number))
            return Result.Fail<Phone>(PhoneErrors.PhoneIsInvalid);
        
        Phone phone = new(number);
        
        return Result.Ok(phone);
    }

    private static string FormatFields(string number)
    {
        return number.Trim()
            .Replace("(", "")
            .Replace(")", "")
            .Replace("-", "")
            .Replace(" ", "");
    }
    
    private static bool IsValid(string number) => Regex.IsMatch(number, _pattern);
}

public sealed record PhoneErrors(string Code, string Message, ErrorType Type) : IError
{
    public static Error PhoneIsRequired => new("PhoneErrors.PhoneIsRequired", "Telefone é obrigatório", ErrorType.Validation);

    public static Error PhoneIsInvalid => new("PhoneErrors.PhoneIsInvalid", "Telefone inválido", ErrorType.Validation);
}