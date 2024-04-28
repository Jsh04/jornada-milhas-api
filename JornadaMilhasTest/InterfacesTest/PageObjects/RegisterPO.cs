using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Application.Commands.UserCommands.RegisterUser;
using JornadaMilhas.Core.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JornadaMilhasTest.InterfacesTest.PageObjects;

public class RegisterPO
{
    private IWebDriver driver;

    private By btnRegister;

    private By inputName;

    private By inputDtBirth;

    private By inputGenreMale;

    private By inputGenreFemale;

    private By inputCpf;

    private By inputPhone;

    private By inputCity;

    private By selectState;

    private By inputEmail;

    private By inputConfirmEmail;

    private By inputPassword;

    private By inputConfirmPassword;

    private By inputTerms;

    public RegisterPO(IWebDriver driver)
    {
        this.driver = driver;
        inputName = By.Id("name");
        inputDtBirth = By.Id("dtBirth");
        inputGenreMale = By.Id("male");
        inputGenreFemale = By.Id("female");
        inputCpf = By.Id("cpf");
        inputPhone = By.Id("phone");
        inputCity = By.Id("city");
        selectState = By.Id("state");
        inputEmail = By.Id("email");
        inputConfirmEmail = By.Id("confirmEmail");
        inputPassword = By.Id("password");
        inputConfirmPassword = By.Id("confirmPassword");
        inputTerms = By.Id("terms");
        btnRegister = By.ClassName("register__form-btn");
    }

    public RegisterPO NavigateToPageRegister(string url)
    {
        driver.Navigate().GoToUrl(url);

        return this;
    }

    public RegisterPO SendKeysToUserLimited(RegisterUserCommand usuario)
    {
        driver.FindElement(inputName).SendKeys(usuario.Name);
        driver.FindElement(inputDtBirth).SendKeys(usuario.DtBirth.ToString());
        driver.FindElement(inputGenreMale).Click();
        driver.FindElement(inputCpf).SendKeys(usuario.Cpf);
        driver.FindElement(inputPhone).SendKeys(usuario.Phone);
        driver.FindElement(inputCity).SendKeys(usuario.Address.City);
        
        SelectElement select = new SelectElement(driver.FindElement(selectState));
        select.SelectByValue("PE");
        driver.FindElement(inputEmail).SendKeys(usuario.Mail);
        driver.FindElement(inputConfirmEmail).SendKeys(usuario.ConfirmMail);
        driver.FindElement(inputPassword).SendKeys(usuario.Password);
        driver.FindElement(inputConfirmPassword).SendKeys(usuario.ConfirmPassword);


        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        IWebElement termsCheckbox = wait.Until(drv => drv.FindElement(inputTerms));
        termsCheckbox.Click();

        return this;
    }

    public RegisterPO SendDataUserLimited()
    {
        driver.FindElement(btnRegister).Click();
        return this;
    }
}

