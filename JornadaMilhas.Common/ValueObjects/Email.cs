using System.Text.RegularExpressions;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Common.ValueObjects;

public class Email
{
    public string Address { get; } = string.Empty;

    private const string _pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    
    public Email()
    {
        
    }

    private Email(string mail)
    {
        Address = mail;
    }
    
    public static Result<Email> Create(string mail)
    {
        if (string.IsNullOrEmpty(mail))
            return Result.Fail<Email>(EmailErrors.EmailIsRequired);

        var emailAddress = mail.ToLower().Trim();
        
        if (emailAddress.Length < 5)
            return Result.Fail<Email>(EmailErrors.EmailIsTooShort);

        if (emailAddress.Length > 255)
            return Result.Fail<Email>(EmailErrors.EmailIsTooLong);

        if (!Regex.IsMatch(emailAddress, _pattern))
            return Result.Fail<Email>(EmailErrors.EmailIsInvalid);

        var email = new Email(emailAddress);
        
        return Result.Ok(email);
    }
}

public sealed record EmailErrors(string Code, string Message, ErrorType Type) : IError
{
    public static Error EmailIsRequired => new("EmailErrors.EmailIsRequired", "Email é obrigatório", ErrorType.Validation);
    public static Error EmailIsInvalid => new("EmailErrors.EmailIsInvalid", "Email é inválido", ErrorType.Validation);
    
    public static Error EmailIsTooLong=> new("EmailErrors.EmailIsTooLong", "Email muito longo", ErrorType.Validation);
    public static Error EmailIsTooShort => new("EmailErrors.EmailIsTooShort", "Email muito curto", ErrorType.Validation);
}