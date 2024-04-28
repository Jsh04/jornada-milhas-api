using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Enums;

namespace JornadaMilhas.Core.Entities.Users;

public class User : BaseEntity
{
    public string Name { get; set; }

    public DateOfBirth DtBirth { get; set; }

    public EnumGenre Genre { get; set; }

    public EnumRole UserRole { get; set; }

    public Cpf Cpf { get; }

    public string Phone { get; set; }

    public Address Address { get; set; }

    public byte[]? Picture { get; set; }

    public string? CodeEmployee { get; set; }
    
    public string  Email { get; set; }

    public string ConfirmEmail { get; set; }

    public string Password { get; set; }

    public bool EmailExists { get; set; }

    public ICollection<Depoimento> Depoimentos { get; set; }

    public static UserBuilder CreateBuilder => UserBuilder.Create();

    protected User(string name, 
        DateOfBirth dtBirth, 
        EnumGenre genre, 
        EnumRole userRole, 
        Cpf cpf, 
        string phone, 
        Address address, 
        byte[]? picture, 
        string? codeEmployee, 
        string email, 
        string confirmEmail, 
        string password)
    {
        Name = name;
        DtBirth = dtBirth;
        Genre = genre;
        UserRole = userRole;
        Cpf = cpf;
        Phone = phone;
        Address = address;
        Picture = picture;
        CodeEmployee = codeEmployee;
        Email = email;
        ConfirmEmail = confirmEmail;
        Password = password;
    }
    
    public Result<User> Create(string name, 
        DateOfBirth dtBirth, 
        EnumGenre genre, 
        EnumRole userRole, 
        Cpf cpf, 
        string phone, 
        Address address, 
        byte[]? picture, 
        string? codeEmployee, 
        string email, 
        string confirmEmail, 
        string password)
    {
        var user = new User(name, dtBirth, genre, userRole, cpf, phone, address, picture, codeEmployee, email,
            confirmEmail, password);
        
        return Result<User>.Ok(user);
    }
}
