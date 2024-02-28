using JornadaMilhasTest.InterfacesTest.Fixtures;

namespace JornadaMilhasTest.InterfacesTest;

[SetUpFixture]
public class SharingResources
{

    public static TestFixtureJornada Fixture { get; set; }

    [OneTimeSetUp]
    public void InstaceWebDriver() => Fixture = new TestFixtureJornada();
    

    [OneTimeTearDown]
    public void QuitPageNavigator() => Fixture.Dispose();
}
