using JornadaMilhasTest.InterfacesTest.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.InterfacesTest;

[SetUpFixture]
public class SharingResources
{

    public static TestFixtureJornada Fixture { get; set; }

    [OneTimeSetUp]
    public void InstaceWebDriver()
    {
        Fixture = new TestFixtureJornada();
    }

    [OneTimeTearDown]
    public void QuitPageNavigator() => Fixture.Dispose();
}
