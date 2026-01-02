using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer.InputModels;
using JornadaMilhas.Common.Entity.Users.Enums;
using JornadaMilhasTest.InterfacesTest.Helper;
using JornadaMilhasTest.InterfacesTest.PageObjects;
using OpenQA.Selenium;

namespace JornadaMilhasTest.InterfacesTest.Tests.RegisterTests;

[TestFixture]
public class RegisterUserLimitedTest
{
    private readonly IWebDriver driver;

    public RegisterUserLimitedTest()
    {
        driver = SharingResources.Fixture.driver;
    }

    [Test]
    public void DeverarAparecerPaginaDeConfirmacaoDeEmailAposCadastro()
    {
        //arrange
        var usuario = new CustomerCreateInputModel("José Silvio Henrique Barros de Souza",
            DateTime.Parse("02-04-2004"), EnumGenre.Male, "12548169090", "81992659528",
            new AddressInputModel("Recife", "PE", string.Empty, string.Empty, string.Empty), "josesilvio.bs@gmail.com", "josesilvio.bs@gmail.com", "Senha123",
            "Senha123");

        var registerPo = new RegisterPO(driver);

        //act
        registerPo.NavigateToPageRegister("http://localhost:8080/cadastro")
            .SendKeysToUserLimited(usuario)
            .SendDataUserLimited();

        //assert
        var isConfirmMailPage =
            TestHelper.ReturnValidationOfTimeWait(drv => drv.PageSource.Contains("Confirme Seu E-mail"), driver, 10);

        Assert.That(isConfirmMailPage, Is.True);
    }
}