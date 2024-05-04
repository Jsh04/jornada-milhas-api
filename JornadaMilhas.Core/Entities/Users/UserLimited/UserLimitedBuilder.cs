using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Entities.Users.UserLimited;

public class UserLimitedBuilder : UserBuilder<UserLimited, UserLimitedBuilder>
{

    public static UserLimitedBuilder Create() => new();

    public override Result<UserLimited> Build()
    {
        var userLimitedResult = UserLimited.Create(_name, _dtBirth, _genre, _cpf, _phone, _adress, _picture, _mail, _confirmMail, _password);

        if (!userLimitedResult.Success)
            return Result.Fail<UserLimited>(userLimitedResult.Errors);

        return userLimitedResult;


    }
}
