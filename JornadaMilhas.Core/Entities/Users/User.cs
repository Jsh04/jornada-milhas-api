using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Enums;

namespace JornadaMilhas.Core.Entities.Users;

public abstract class User : BaseEntity
{
    public string Name { get; set; }

    public DateOfBirth DtBirth { get; set; }

    public EnumGenre Genre { get; set; }

    public Cpf Cpf { get; }

    public Phone Phone { get; set; }

    public Address Address { get; set; }

    public byte[]? Picture { get; set; }

    public Email Email { get; set; }

    public Email ConfirmEmail { get; set; }

    public string Password { get; set; }


    protected User(string name,
        DateOfBirth dtBirth,
        EnumGenre genre,
        Cpf cpf,
        Phone phone,
        Address address,
        byte[]? picture,
        Email email,
        Email confirmEmail,
        string password)
    {
        Name = name;
        DtBirth = dtBirth;
        Genre = genre;
        Cpf = cpf;
        Phone = phone;
        Address = address;
        Picture = picture;
        Email = email;
        ConfirmEmail = confirmEmail;
        Password = password;
    }
}
    
    
