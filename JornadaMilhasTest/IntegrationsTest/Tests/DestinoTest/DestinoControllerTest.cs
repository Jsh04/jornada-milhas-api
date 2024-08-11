using AutoFixture;
using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.Util;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhasTest.IntegrationsTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JornadaMilhasTest.IntegrationsTest.Tests.DestinoTest;

[TestFixture]
[Category("IntegrationTest")]
[Explicit("Testes de integração")]
public class DestinoControllerTest
{
    private HttpClient client;
    private Fixture fixture;

    public DestinoControllerTest()
    {
        client = SharingResources.Fixture.client;
        fixture = SharingResources.AutoFixture;
    }

    [Test(Description = "Faz requisição para controller com um objeto destino fictício e é esperado que persista os dados")]
    public async Task DeverarCadastrarDestinoCriado()
    {
        //arrange
        List<string> randomsBase64 = new();
        var destinoDto = fixture.Create<RegisterDestinyCommand>();

        randomsBase64.Add(GenerateRandom.GenerateRandomBase64());
        randomsBase64.Add(GenerateRandom.GenerateRandomBase64());
        randomsBase64.Add(GenerateRandom.GenerateRandomBase64());

        destinoDto.Images.AddRange(randomsBase64);

        var url = "/destinos";

        var stringContent = new StringContent(TestHelper.SerializerObjToJson(destinoDto), encoding: Encoding.UTF8, TestHelper.ContentTypeJson);

        //act
        var response = await client.PostAsync(url, stringContent);

        //assert
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task DeverarRetornarOsDestinosCadastrados()
    {
        //arrrange
        var uri = new UriBuilder(client.BaseAddress + "destinos")
        {
            Query = $"size={10}&page={0}"
        };

        //act
        var response = await client.GetAsync(uri.ToString());

        string content = await response.Content.ReadAsStringAsync();

        var destinos = JsonSerializer.Deserialize<List<Destiny>>(content)!;

        //assert
        Assert.That(destinos, Has.Count.EqualTo(1));
    }



}
