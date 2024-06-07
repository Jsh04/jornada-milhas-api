﻿using JornadaMilhasTest.InterfacesTest.Helper;
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
           .FillFormsLogin("josesilvio.bs@gmail.com", "Senha123")
           .SubmitForm();
        //assert
        
        bool dashboardUrl = TestHelper.ReturnValidationOfTimeWait(drv => drv.Url.Contains('/'), driver);
        Assert.That(dashboardUrl);
    }
}
