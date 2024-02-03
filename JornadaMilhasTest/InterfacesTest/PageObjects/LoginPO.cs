using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.InterfacesTest.PageObjects;

public class LoginPageObject
{
    private IWebDriver driver;
    private By inputLogin;
    private By inputPassword;
    private By btnLogin;
    private By btnLoginHeader;

    public LoginPageObject(IWebDriver driver)
    {
        this.driver = driver;
        inputLogin = By.Id("email");
        inputPassword = By.Id("password");
        btnLogin = By.CssSelector(".login__form-btn button");
        btnLoginHeader = By.ClassName("header__btns-login");
    }

    public LoginPageObject NavigateToPage()
    {
        driver.Navigate().GoToUrl("http://localhost:8080");
        driver.FindElement(btnLoginHeader).Click();
        return this;
    }

    public void SubmitForm()
    {
        driver.FindElement(btnLogin).Click();
    }

    public LoginPageObject FillFormsLogin(string email, string senha)
    {
        driver.FindElement(inputLogin).SendKeys(email);
        driver.FindElement(inputPassword).SendKeys(senha);
        return this;
    }
}
