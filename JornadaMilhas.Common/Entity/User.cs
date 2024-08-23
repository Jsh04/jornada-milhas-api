using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Common.Enums;
using JornadaMilhas.Common.DomainEvent;


namespace JornadaMilhas.Common.Entities;

public abstract class User : BaseEntity
{
    public string Name { get; protected set; }

    public DateOfBirth DtBirth { get; protected set; }

    public EnumGenre Genre { get; protected set; }

    public Cpf Cpf { get; protected set; }

    public Phone Phone { get; protected set; }
    
    public Address Address { get; protected set; }

    public byte[]? Picture { get; protected set; }

    public Email Email { get; protected set; }

    public Email ConfirmEmail { get; protected set; }

    public string Password { get; protected set; }

    protected User() { }
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

    public void ThrowEvent(IDomainEvent domainEvent) =>
       RaiseDomainEvent(domainEvent);
}
    
    
