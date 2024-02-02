namespace JornadaMilhasTest.InterfacesTest.Fixtures;

[SetUpFixture]
public class SharingResources
{
    public static TestFixture Fixture { get; set; }

    public SharingResources() { }

    [OneTimeSetUp]
    public void ConfigurarRecurso() => Fixture = new TestFixture();

    [OneTimeTearDown]
    public void LimparRecurso()
    {
        Fixture.Dispose();
    }
}
