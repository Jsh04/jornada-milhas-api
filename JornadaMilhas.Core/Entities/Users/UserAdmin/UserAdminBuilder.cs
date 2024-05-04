using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;


namespace JornadaMilhas.Core.Entities.Users.UserAdmin;

public class UserAdminBuilder : UserBuilder<UserAdmin, UserAdminBuilder>
{
    protected string _codeEmployee;

    public static UserAdminBuilder Create() => new();

    public UserAdminBuilder WithCodeEmployee(string codeEmployee)
    {
        _codeEmployee = codeEmployee;
        return this;
    }

    public override Result<UserAdmin> Build()
    {
        var userAdminResult = UserAdmin.Create(_name, _dtBirth, _genre, _cpf, _phone, _adress, _codeEmployee, _picture, _mail, _confirmMail, _password);

        if (!userAdminResult.Success)
            return Result.Fail<UserAdmin>(userAdminResult.Errors);

        return userAdminResult;
    }
}

