using AutoFixture;
using JornadaMilhasTest.IntegrationsTest.Fixtures;

namespace JornadaMilhasTest.IntegrationsTest;

[SetUpFixture]
public class SharingResources
{
    public static TestFixtureIntegration Fixture;
    public static Fixture AutoFixture;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Fixture = new TestFixtureIntegration();
        AutoFixture = new Fixture();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Fixture.Dispose();
    }
}