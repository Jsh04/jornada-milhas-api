using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JornadaMilhasTest.InterfacesTest.PageObjects;

public class RegisterPO
{
    private readonly By btnRegister;
    private readonly IWebDriver driver;

    private readonly By inputCity;

    private readonly By inputConfirmEmail;

    private readonly By inputConfirmPassword;

    private readonly By inputCpf;

    private readonly By inputDtBirth;

    private readonly By inputEmail;

    private By inputGenreFemale;

    private readonly By inputGenreMale;

    private readonly By inputName;

    private readonly By inputPassword;

    private readonly By inputPhone;

    private readonly By inputTerms;

    private readonly By selectState;

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

    public RegisterPO SendKeysToUserLimited(RegisterCustomerCommand usuario)
    {
        driver.FindElement(inputName).SendKeys(usuario.Name);
        driver.FindElement(inputDtBirth).SendKeys(usuario.DtBirth.ToString());
        driver.FindElement(inputGenreMale).Click();
        driver.FindElement(inputCpf).SendKeys(usuario.Cpf);
        driver.FindElement(inputPhone).SendKeys(usuario.Phone);
        driver.FindElement(inputCity).SendKeys(usuario.Address.City);

        var select = new SelectElement(driver.FindElement(selectState));
        select.SelectByValue("PE");
        driver.FindElement(inputEmail).SendKeys(usuario.Mail);
        driver.FindElement(inputConfirmEmail).SendKeys(usuario.ConfirmMail);
        driver.FindElement(inputPassword).SendKeys(usuario.Password);
        driver.FindElement(inputConfirmPassword).SendKeys(usuario.ConfirmPassword);


        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        var termsCheckbox = wait.Until(drv => drv.FindElement(inputTerms));
        termsCheckbox.Click();

        return this;
    }

    public RegisterPO SendDataUserLimited()
    {
        driver.FindElement(btnRegister).Click();
        return this;
    }
}