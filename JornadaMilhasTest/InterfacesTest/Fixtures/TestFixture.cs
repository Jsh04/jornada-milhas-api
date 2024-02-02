using JornadaMilhasTest.InterfacesTest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace JornadaMilhasTest.InterfacesTest.Fixtures;

public class TestFixture : IDisposable
{
    public IWebDriver driver;

    public TestFixture()
    {
        driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
    }

    public void Dispose() => driver.Quit();

}
