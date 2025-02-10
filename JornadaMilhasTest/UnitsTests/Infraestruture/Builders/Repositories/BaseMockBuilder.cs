using Moq;

namespace JornadaMilhasTest.UnitsTests.Builders;

public abstract class BaseMockBuilder<TInterface> where TInterface : class
{
    protected readonly Mock<TInterface> _mock;

    protected BaseMockBuilder()
    {
        _mock = new Mock<TInterface>();
    }

    public virtual Mock<TInterface> Build()
    {
        return _mock;
    }
}