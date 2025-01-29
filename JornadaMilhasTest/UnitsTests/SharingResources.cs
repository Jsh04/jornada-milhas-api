using AutoFixture;

namespace JornadaMilhasTest.UnitsTests;

[SetUpFixture]
public class SharingResources
{
    public static Fixture AutoFixture;

    [OneTimeSetUp]
    public void InicializeObjects()
    {
        AutoFixture = new Fixture();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
    }
}