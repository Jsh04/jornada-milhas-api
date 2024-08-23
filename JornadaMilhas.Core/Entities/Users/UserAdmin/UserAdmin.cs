using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Enums;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Users.UserLimited;

namespace JornadaMilhas.Core.Entities.Users.UserAdmin;

public class UserAdmin : User
{
    public string CodeEmployee { get; set; }

    protected UserAdmin(string name, DateOfBirth dtBirth, EnumGenre genre, Cpf cpf, Phone phone, Address address, string codeEmployee, byte[]? picture, Email email, Email confirmEmail, string password)
        : base(name, dtBirth, genre, cpf, phone, address, picture, email, confirmEmail, password)
    {
        CodeEmployee = codeEmployee;
    }

    protected UserAdmin() { }

    public static UserLimitedBuilder CreateBuilder => UserLimitedBuilder.Create();

    public static Result<UserAdmin> Create(string name,
            DateOfBirth dtBirth,
            EnumGenre genre,
            Cpf cpf,
            Phone phone,
            Address address,
            string codeEmployee,
            byte[]? picture,
            Email email,
            Email confirmEmail,
            string password)
    {
        var userAdmin = new UserAdmin(name, dtBirth, genre, cpf, phone, address, codeEmployee, picture, email, confirmEmail, password);

        return Result<User>.Ok(userAdmin);
    }
}