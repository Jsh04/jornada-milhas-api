using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Enums;

namespace JornadaMilhas.Core.Entities.Users;

public class UserAdmin : User
{
    public string CodeEmployee { get; set; }

    protected UserAdmin(string name, DateOfBirth dtBirth, EnumGenre genre, Cpf cpf, Phone phone, Address address, string codeEmployee,byte[]? picture, Email email, Email confirmEmail, string password) 
        : base(name, dtBirth, genre, cpf, phone, address, picture, email, confirmEmail, password)
    {
        CodeEmployee = codeEmployee;
    }   
    
    public static UserBuilder CreateBuilder => UserBuilder.Create();
    
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