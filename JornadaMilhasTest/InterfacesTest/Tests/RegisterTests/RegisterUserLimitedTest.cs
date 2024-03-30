using AutoFixture;
using JornadaMilhas.Core.DTO.Usuario;
using JornadaMilhas.Core.Entities;
using JornadaMilhasTest.InterfacesTest.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JornadaMilhasTest.InterfacesTest.Tests.RegisterTests;

[TestFixture]
public class RegisterUserLimitedTest
{
    private IWebDriver driver;
    private Fixture Fixture;

    public RegisterUserLimitedTest()
    {
        driver = SharingResources.Fixture.driver;
        Fixture = SharingResources.AutoFixture;
    }

    [Test]
    public void DeverarAparecerPaginaDeConfirmacaoDeEmailAposCadastro()
    {
        //arrange
        var usuario = new UsuarioCadastroDTO()
        {
            Name = "José Silvio Henrique Barros de Souza",
            Cpf = "70188588442",
            City = "Recife",
            DtBirth = DateTime.Parse("02-04-2004"),
            Phone = "81992659528",
            Email = "josesilvio.bs@gmail.com",
            ConfirmEmail = "josesilvio.bs@gmail.com",
            Password = "Senha123",
            ConfirmPassword = "Senha123",
            
        };
        
        var registerPo = new RegisterPO(driver);
        
        //act
        registerPo.NavigateToPageRegister("http://localhost:8080/cadastro")
            .SendKeysToUserLimited(usuario)
            .SendDataUserLimited();

        //assert

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        bool isConfirmMailPage = wait.Until(drv => drv.PageSource.Contains("Confirme Seu E-mail"));

        Assert.That(isConfirmMailPage, Is.True);
    }



}

