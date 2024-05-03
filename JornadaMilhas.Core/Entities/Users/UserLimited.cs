using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Enums;

namespace JornadaMilhas.Core.Entities.Users;

public class UserLimited : User
{
    
    public ICollection<Depoimento> Depoimentos { get; set; }
    
    public bool EmailExists { get; set; }
    
    protected UserLimited(string name, DateOfBirth dtBirth, EnumGenre genre, Cpf cpf, Phone phone, Address address, byte[]? picture, Email email, 
        Email confirmEmail, string password) 
        : base(name, dtBirth, genre, cpf, phone, address, picture, email, confirmEmail, password)
    {}
        
    public static UserBuilder CreateBuilder => UserBuilder.Create();
        
    public Result<UserLimited> Create(string name, 
            DateOfBirth dtBirth, 
            EnumGenre genre, 
            EnumRole userRole, 
            Cpf cpf, 
            Phone phone, 
            Address address, 
            byte[]? picture, 
            string? codeEmployee, 
            Email email, 
            Email confirmEmail, 
            string password)
        {
            var userLimited = new UserLimited(name, dtBirth, genre, cpf, phone, address, picture, email,
                confirmEmail, password);
            
            return Result<User>.Ok(userLimited);
        }
    
}