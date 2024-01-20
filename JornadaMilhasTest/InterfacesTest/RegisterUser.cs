using JornadaMilhasTest.InterfacesTest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.InterfacesTest;

public class RegisterUser : IDisposable
{
    private readonly IWebDriver driver;

    public RegisterUser()
    {
        driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
    }

    public void Dispose()
    {
        driver.Quit();
    }

    [Test]
    public void TesteDeAberturaDaPaginaPrincipal()
    {

        //act 
        driver.Navigate().GoToUrl("http://localhost:8080");

        //assert
        StringAssert.Contains("Destinos", driver.PageSource);
    }

    [Test]
    public void AoEntrarNaHomeIrParaPaginaDeCadastro()
    {

        //act 
        driver.Navigate().GoToUrl("http://localhost:8080");
        
        var btnRegister = driver.FindElement(By.ClassName("header__btns-register"));
        
        btnRegister.Click();

        //assert
        StringAssert.Contains("Crie sua conta", driver.PageSource);
    }
}
