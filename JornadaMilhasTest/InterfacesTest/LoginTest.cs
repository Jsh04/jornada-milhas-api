
using OpenQA.Selenium;
using NUnit.Framework.Internal;
using JornadaMilhasTest.InterfacesTest.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using JornadaMilhasTest.InterfacesTest.Fixtures;

namespace JornadaMilhasTest.InterfacesTest;

[TestFixture]
public class LoginTest
{
    private readonly IWebDriver driver;

    public LoginTest()
    {
        driver = SharingResources.Fixture.driver;
    }

    [Test]
    public void DeveraAparecerModalComLoginSucesso()
    {

        //arrange
        var loginPO = new LoginPageObject(driver);

        //act
        loginPO.NavigateToPage()
           .FillFormsLogin("josesilvio.bs@gmail.com", "Silvio142536")
           .SubmitForm();
        //assert
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        bool dashboardUrl = wait.Until(drv => drv.Url.Contains("dashboard"));
        Assert.That(dashboardUrl);
    }

    
}
