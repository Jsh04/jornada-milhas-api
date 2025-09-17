using System.ComponentModel.DataAnnotations;
using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users.Enums;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Users.Enums;

namespace JornadaMilhas.Core.Users;

public abstract class User : BaseEntity 
{
    
    public string Name { get; protected set; }

    public DateOfBirth DtBirth { get; protected set; }

    public EnumGenre Genre { get; protected set; }

    public Cpf Cpf { get; protected set; }

    public Phone Phone { get; protected set; }

    public Address Address { get; protected set; }

    public Email Email { get; protected set; }

    public Email ConfirmEmail { get; protected set; }

    [MaxLength(50)]
    public string Password { get; protected set; }

    public EnumRole Role { get; protected set; }
    
    protected User
    (
        string name, 
        DateOfBirth dtBirth, 
        EnumGenre genre, 
        Cpf cpf, 
        Phone phone, 
        Address address, 
        Email email, 
        Email confirmEmail, 
        string password
    )
    {
        Name = name;
        DtBirth = dtBirth;
        Genre = genre;
        Cpf = cpf;
        Phone = phone;
        Address = address;
        Email = email;
        ConfirmEmail = confirmEmail;
        Password = password;
    }
    
    protected User(){}
    
    public void ThrowEvent(IDomainEvent domainEvent)
    {
        RaiseDomainEvent(domainEvent);
    }
}