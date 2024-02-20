using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhasTest.InterfacesTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JornadaMilhasTest.InterfacesTest.Tests.RegisterDestinyTest;

[TestFixture]
public class RegisterDestinyTest
{
    private readonly IWebDriver _driver;

    public RegisterDestinyTest()
    {
        _driver = SharingResources.Fixture.driver;
    }

    [Test]
    public void DeverarAparecerModalComDestinoCadastradoComSucesso()
    {
        //arrange
        var registerDestinyPo = new RegisterDestinyPO(_driver);
        List<string> pathsFiles = new()
        {
            @"E:\\Estudo\\Projetos\\Challenge Front-End\\Vue.js\\JornadaMilhas\\src\\assets\\Imagens\\Card-Atacama.png",
            @"E:\\Estudo\\Projetos\\Challenge Front-End\\Vue.js\\JornadaMilhas\\src\\assets\\Imagens\\Atacama-destino2.png"
        };
        string nameDestino = "Atacama";
        string price = "500";
        string subtitle = "O Deserto do Atacama: Onde a Terra Encontra o Infinito";
        string descriptionEnglish =
            "Beyond its natural wonders, Atacama offers a wide range of activities and experiences for travelers to indulge in. Adventure enthusiasts can embark on thrilling excursions such as sandboarding down the colossal dunes or hiking to the stunning turquoise lagoons nestled within the desert. The geothermal springs provide a perfect opportunity to relax and rejuvenate amidst the arid surroundings. Cultural enthusiasts can explore the rich heritage of the indigenous communities that have inhabited the region for centuries, learning about their traditions, crafts, and way of life. Additionally, Atacama's proximity to the Pacific coast allows for a diverse itinerary, combining the desert experience with visits to charming coastal towns and beaches. Whether you seek adrenaline-pumping adventures, serene natural beauty, or cultural immersion, Atacama offers a remarkable and unforgettable journey that caters to every traveler's desires.";
        string descriptionPortuguese =
            "Além de suas maravilhas naturais, o Atacama oferece uma ampla variedade de atividades e experiências para os viajantes desfrutarem. Os entusiastas de aventura podem embarcar em excursões emocionantes, como a prática de sandboard nas dunas colossais ou fazer trilhas até as deslumbrantes lagoas turquesa escondidas no deserto. As fontes termais oferecem uma oportunidade perfeita para relaxar e rejuvenescer em meio ao ambiente árido. Os entusiastas da cultura podem explorar o rico patrimônio das comunidades indígenas que habitam a região há séculos, aprendendo sobre suas tradições, artesanato e modo de vida. Além disso, a proximidade do Atacama com a costa do Pacífico permite um itinerário diversificado, combinando a experiência no deserto com visitas a encantadoras cidades costeiras e praias. Se você busca aventuras cheias de adrenalina, beleza natural serena ou imersão cultural, o Atacama oferece uma jornada notável e inesquecível que atende aos desejos de cada viajante.";

        //act
        registerDestinyPo
            .NavigateToPageAddDestiny()
            .SendKeysInFormDestinyRegister(pathsFiles, nameDestino, subtitle, price, descriptionPortuguese, descriptionEnglish)
            .ClickBtnToSendData();

        //assert
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        var isModalSucess  = wait.Until(drv => drv.PageSource.Contains("Destino Cadastrado com sucesso"));
        Assert.That(isModalSucess);

    }
}

