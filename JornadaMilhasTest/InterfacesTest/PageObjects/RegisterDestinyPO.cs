using OpenQA.Selenium;

namespace JornadaMilhasTest.InterfacesTest.PageObjects;

public class RegisterDestinyPO
{
    private readonly IWebDriver driver;

    private readonly By _inputFiles;

    private readonly By _nameDestiny;

    private readonly By _subtitleDestiny;

    private readonly By _priceDestiny;

    private readonly By _descriptionPortuguese;

    private readonly By _destinationEnglish;

    private readonly By _btnSendData;

    public RegisterDestinyPO(IWebDriver driver)
    {
        this.driver = driver;
        _inputFiles = By.CssSelector(".filepond--root .filepond--browser");
        _nameDestiny = By.Id("Name");
        _subtitleDestiny = By.Id("Subtitle");
        _priceDestiny = By.Id("Price");
        _descriptionPortuguese = By.Id("DescriptionPortuguese");
        _destinationEnglish = By.Id("DescriptionEnglish");
        _btnSendData = By.ClassName("register__form-btn");
    }

    public RegisterDestinyPO NavigateToPageAddDestiny()
    {
        driver.Navigate().GoToUrl("http://localhost:8080/admin/destino/cadastro");
        return this;
    }

    public RegisterDestinyPO SendKeysInFormDestinyRegister(List<string> pathsFiles, string name, string subtitle, string price, string descriptionPort, string descriptionEnglish)
    {
        var inputFile = driver.FindElement(_inputFiles);
        
        pathsFiles.ForEach(filePath =>
        {
            inputFile.SendKeys(filePath);
            Thread.Sleep(5000);
        });


        driver.FindElement(_nameDestiny).SendKeys(name);
        driver.FindElement(_subtitleDestiny).SendKeys(subtitle);
        driver.FindElement(_priceDestiny).SendKeys(price);
        driver.FindElement(_descriptionPortuguese).SendKeys(descriptionPort);
        driver.FindElement(_destinationEnglish).SendKeys(descriptionEnglish);

        return this;
    }

    public RegisterDestinyPO ClickBtnToSendData()
    {
        driver.FindElement(_btnSendData).Click();
        return this;
    }

}
