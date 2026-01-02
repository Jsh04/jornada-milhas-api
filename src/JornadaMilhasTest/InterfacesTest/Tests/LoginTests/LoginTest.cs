using JornadaMilhasTest.InterfacesTest.Helper;
using JornadaMilhasTest.InterfacesTest.PageObjects;
using OpenQA.Selenium;

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
            .FillFormsLogin("josesilvio.bs@gmail.com", "Senha123")
            .SubmitForm();
        //assert

        var dashboardUrl = TestHelper.ReturnValidationOfTimeWait(drv => drv.Url.Contains('/'), driver);
        Assert.That(dashboardUrl);
    }
}