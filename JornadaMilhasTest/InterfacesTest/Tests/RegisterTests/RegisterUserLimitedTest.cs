using AutoFixture;
using JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;
using JornadaMilhas.Common.InputDto;
using JornadaMilhasTest.InterfacesTest.PageObjects;
using JornadaMilhas.Common.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using JornadaMilhasTest.InterfacesTest.Helper;

namespace JornadaMilhasTest.InterfacesTest.Tests.RegisterTests;

[TestFixture]
public class RegisterUserLimitedTest
{
    private IWebDriver driver;

    public RegisterUserLimitedTest()
    {
        driver = SharingResources.Fixture.driver;
    }

    [Test]
    public void DeverarAparecerPaginaDeConfirmacaoDeEmailAposCadastro()
    {
        //arrange
        var usuario = new RegisterUserLimitedCommand("José Silvio Henrique Barros de Souza", DateTime.Parse("02-04-2004"), EnumGenre.Male, "12548169090", "81992659528", new AddressInputDto(City: "Recife", State: "PE"), "josesilvio.bs@gmail.com", "josesilvio.bs@gmail.com", "Senha123", "Senha123");

        var registerPo = new RegisterPO(driver);

        //act
        registerPo.NavigateToPageRegister("http://localhost:8080/cadastro")
            .SendKeysToUserLimited(usuario)
            .SendDataUserLimited();

        //assert
        bool isConfirmMailPage = TestHelper.ReturnValidationOfTimeWait(drv => drv.PageSource.Contains("Confirme Seu E-mail"), driver, 10);

        Assert.That(isConfirmMailPage, Is.True);
    }



}

