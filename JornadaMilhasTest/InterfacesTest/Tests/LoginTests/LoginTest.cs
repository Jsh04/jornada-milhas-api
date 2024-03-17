using JornadaMilhasTest.InterfacesTest.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JornadaMilhasTest.InterfacesTest.Tests.LoginTests;


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
        bool dashboardUrl = wait.Until(drv => drv.Url.Contains("/"));
        Assert.That(dashboardUrl);
    }
}
