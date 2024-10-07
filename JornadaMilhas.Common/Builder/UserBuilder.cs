
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Enums;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Common.ValueObjects;

namespace JornadaMilhas.Common.Builder;

public abstract class UserBuilder<TUser, TBuilder>
    where TUser : User
    where TBuilder : UserBuilder<TUser, TBuilder>
{
    protected string _name;

    protected DateOfBirth _dtBirth;

    protected EnumGenre _genre;

    protected Cpf _cpf;

    protected Phone _phone;

    protected Address _adress;

    protected byte[]? _picture;

    protected Email _mail;

    protected Email _confirmMail;

    protected string _password;

    private readonly TBuilder _builder;

    protected List<IError> _errors = new();

    protected UserBuilder()
    {
        _builder = this as TBuilder;
    }

    public TBuilder WithName(string name)
    {
        _name = name;
        return _builder;
    }

    public TBuilder WithDtOfBirth(DateTime? dateTime)
    {
        var dtBirthResult = DateOfBirth.Create(dateTime);
        if (!dtBirthResult.Success)
            _errors.AddRange(dtBirthResult.Errors);

        _dtBirth = dtBirthResult.ValueOrDefault;
        
        return _builder;
    }

    public TBuilder WithGenre(EnumGenre genre)
    {
        _genre = genre;
        return _builder;
    }

    public TBuilder WithPicture(byte[]? picture)
    {
        _picture = picture;
        return _builder;
    }

    public TBuilder WithPhone(string phone)
    {
        var phoneResult = Phone.Create(phone);

        if (!phoneResult.Success)
            _errors.AddRange(phoneResult.Errors);

        _phone = phoneResult.ValueOrDefault;

        return _builder;
    }

    public TBuilder WithAddress(string? street, string city, string state, string? district, string? zipCode)
    {
        var address = Address.Create(city, state, zipCode, street, district);

        if (!address.Success)
            _errors.AddRange(address.Errors);

        _adress = address.ValueOrDefault;

        return _builder;
    }

    public TBuilder WithDocumentation(string cpf)
    {
        var cpfResult = Cpf.Create(cpf);

        if (!cpfResult.Success)
            _errors.AddRange(cpfResult.Errors);
        
        _cpf = cpfResult.ValueOrDefault;
        
        return _builder;
        
    }

    public TBuilder WithEmail(string email) 
    {
        var emailResult = Email.Create(email);
        if (!emailResult.Success)
            _errors.AddRange(emailResult.Errors);

        _mail = emailResult.ValueOrDefault;

        return _builder;
    }
    public TBuilder WithConfirmMail(string confirmMail)
    {
        var confirmMailResult = Email.Create(confirmMail);

        if (!confirmMailResult.Success)
            _errors.AddRange(confirmMailResult.Errors); 

        _confirmMail = confirmMailResult.ValueOrDefault;

        return _builder;
    }

    public TBuilder WithPassword(string password)
    {
        _password = password;
        return _builder;
    }
    
    public abstract Result<TUser> Build();
}
