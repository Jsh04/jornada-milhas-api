using JornadaMilhasTest.InterfacesTest.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JornadaMilhasTest.InterfacesTest.Fixtures;

public class TestFixtureJornada : IDisposable
{

    public IWebDriver driver;

    public TestFixtureJornada() => driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
    
    public void Dispose() => GC.SuppressFinalize(this); 

}
