using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Enums;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace JornadaMilhas.Core.Entities.Users.UserLimited;

public class UserLimited : User
{
    public List<Depoimento> Depoimentos { get; } = new();

    public bool EmailExists { get; private set; } 

    protected UserLimited(string name, DateOfBirth dtBirth, EnumGenre genre, Cpf cpf, Phone phone, Address address, byte[]? picture, Email email,
        Email confirmEmail, string password)
        : base(name, dtBirth, genre, cpf, phone, address, picture, email, confirmEmail, password)
    { }

    protected UserLimited() { }

    public static UserLimitedBuilder CreateBuilder => UserLimitedBuilder.Create();

    public static Result<UserLimited> Create(string name,
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
        var userLimited = new UserLimited(name, dtBirth, genre, cpf, phone, address, picture, email,
            confirmEmail, password);

        return Result<User>.Ok(userLimited);
    }

    public void SetEmailExists(bool emailExists) => EmailExists = emailExists;
    

}