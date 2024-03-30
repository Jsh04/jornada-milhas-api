using AutoFixture;
using JornadaMilhasTest.InterfacesTest.Fixtures;

namespace JornadaMilhasTest.InterfacesTest;

[SetUpFixture]
public class SharingResources
{

    public static TestFixtureJornada Fixture { get; set; }
    public static Fixture AutoFixture { get; set; }

    [OneTimeSetUp]
    public void InstaceWebDriver()
    {
        Fixture = new TestFixtureJornada();
        AutoFixture = new Fixture();
    } 
    

    [OneTimeTearDown]
    public void QuitPageNavigator() => Fixture.Dispose();
}
