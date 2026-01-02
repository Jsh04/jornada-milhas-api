using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Common.Results;
using JornadaMilhasTest.UnitsTests.Builders;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Services;

public sealed class UserServiceMockBuilder : BaseMockBuilder<IUserService>
{
    public static UserServiceMockBuilder CreateInstance() => new();

    public UserServiceMockBuilder WithGetCustomerId(Result<long> resultReturn)
    {
        _mock.Setup(x => x.GetCustomerId())
            .Returns(resultReturn);
        
        return this;
    }
    
}