using JornadaMilhasTest.InterfacesTest.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.InterfacesTest.Fixtures;

public class TestFixtureJornada : IDisposable
{

    public IWebDriver driver;

    public TestFixtureJornada()
    {
        driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
    }

    public void Dispose() => driver.Quit();

}
