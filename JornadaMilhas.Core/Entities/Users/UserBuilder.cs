using JornadaMilhas.Common.Builder;

using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Enums;

namespace JornadaMilhas.Core.Entities.Users;

public class UserBuilder : Builder<User>
{
    protected string _name;

    protected DateOfBirth _dtBirth;

    protected EnumGenre _genre;

    protected EnumRole _userRole;

    protected Cpf _cpf;

    protected string _phone;

    protected Address _adress;

    protected byte[]? _picture;

    protected string? _codeEmployee;

    protected string _mail;

    protected string _confirmMail;
    
    protected string _password;
    
    public static UserBuilder Create() => new();

    public UserBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    public UserBuilder WithDtOfBirth(DateTime? dateTime)
    {
        var dtBirthResult = DateOfBirth.Create(dateTime);
        if (!dtBirthResult.Success)
            _errors.AddRange(dtBirthResult.Errors);

        _dtBirth = dtBirthResult.ValueOrDefault;
        
        return this;
    }
    public UserBuilder WithDocumentation(string cpf)
    {
        var cpfResult = Cpf.Create(cpf);

        if (!cpfResult.Success)
            _errors.AddRange(cpfResult.Errors);
        
        _cpf = cpfResult.ValueOrDefault;
        
        return this;
        
    }
    
    public UserBuilder WithPhone(string phone)
    {
        _phone = phone;
        return this;
    }
    
    public UserBuilder WithGenre(EnumGenre genre)
    {
        _genre = genre;
        return this;
    }
    
    public UserBuilder WithAddress(string street, string city, string state, string district, string zipCode)
    {
        var address = Address.Create(city, state, zipCode, street, district);

        if (!address.Success)
            _errors.AddRange(address.Errors);

        _adress = address.ValueOrDefault;
        
        return this;
    }
    
    public UserBuilder WithPicture(byte[]? picture)
    {
        _picture = picture;
        return this;
    }
    
    public UserBuilder WithCodeEmployee(string? codeEmployee)
    {
        _codeEmployee = codeEmployee;
        return this;
    }
    public UserBuilder WithMail(string mail)
    {
        _mail = mail;
        return this;
    }
    
    public UserBuilder WithPassword(string password)
    {
        _password = password;
        return this;
    }
    
    public UserBuilder WithConfirmMail(string confirmMail)
    {
        _confirmMail = confirmMail;
        return this;
    }

    public UserBuilder WithUserRole(EnumRole userRole)
    {
        _userRole = userRole;
        return this;
    }
    
    public override Result<User> Build()
    {
        throw new NotImplementedException();
    }
}
