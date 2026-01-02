using JornadaMilhas.Common.Entity.Users.Enums;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Common.Security;
using JornadaMilhas.Common.ValueObjects;

namespace JornadaMilhas.Core.Entities.Users;

public abstract class UserBuilder<TUser, TBuilder>
    where TUser : User
    where TBuilder : UserBuilder<TUser, TBuilder>
{
    protected readonly List<IError> _errors = new();
    
    public string Name { get; private set; }

    public DateOfBirth DtBirth { get; private set; }

    public EnumGenre Genre { get; private set; }

    public Cpf Cpf { get; private set; }

    public Phone Phone { get; private set; }

    public Address Address { get; private set; }

    public byte[]? Picture { get; private set; }

    public Email Mail { get; private set; }

    public Email ConfirmMail { get; private set; }

    public string Password { get; private set; }

    private readonly TBuilder _builder;

    protected UserBuilder()
    {
        _builder = this as TBuilder;
    }
    
    public TBuilder WithName(string name)
    {
        Name = name;
        return _builder;
    }

    public TBuilder WithDtOfBirth(DateTime? dateTime)
    {
        var dtBirthResult = DateOfBirth.Create(dateTime);

        if (!dtBirthResult.Success)
            _errors.AddRange(dtBirthResult.Errors);
        else
            DtBirth = dtBirthResult.Value;
        
        return _builder;
    }

    public TBuilder WithGenre(EnumGenre genre)
    {
        Genre = genre;
        return _builder;
    }

    public TBuilder WithPicture(byte[]? picture)
    {
        Picture = picture;
        return _builder;
    }

    public TBuilder WithPhone(string phone)
    {
        var phoneResult = Phone.Create(phone);

        if (!phoneResult.Success)
            _errors.AddRange(phoneResult.Errors);
        else
            Phone = phoneResult.ValueOrDefault;

        return _builder;
    }

    public TBuilder WithAddress(string street, string city, string state, string district, string zipCode)
    {
        var address = Address.Create(city, state, zipCode, street, district);

        if (!address.Success)
            _errors.AddRange(address.Errors);
        else
            Address = address.ValueOrDefault;
        
        return _builder;
    }

    public TBuilder WithDocumentation(string cpf)
    {
        var cpfResult = Cpf.Create(cpf);

        if (!cpfResult.Success)
            _errors.AddRange(cpfResult.Errors);
        else
            Cpf = cpfResult.ValueOrDefault;

        return _builder;
    }

    public TBuilder WithEmail(string email)
    {
        var emailResult = Email.Create(email);
        if (!emailResult.Success)
            _errors.AddRange(emailResult.Errors);
        else
            Mail = emailResult.ValueOrDefault;

        return _builder;
    }

    public TBuilder WithConfirmMail(string confirmMail)
    {
        var confirmMailResult = Email.Create(confirmMail);

        if (!confirmMailResult.Success)
            _errors.AddRange(confirmMailResult.Errors);
        else
            ConfirmMail = confirmMailResult.ValueOrDefault;

        return _builder;
    }

    public TBuilder WithPassword(string password)
    {
        Password = PasswordHasher.HashPassword(password);
        return _builder;
    }
    
}