using AutoFixture;
using JornadaMilhas.Application.Util;
using JornadaMilhas.Core.DTO.Destinos;
using JornadaMilhas.Core.Entities;
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
    [Order(1)]
    public async Task DeverarCadastrarDestinoCriado()
    {
        //arrange
        List<string> randomsBase64 = new();
        var destinoDto = fixture.Create<CreateDestinoDTO>();

        randomsBase64.Add(GenerateRandom.GenerateRandomBase64());
        randomsBase64.Add(GenerateRandom.GenerateRandomBase64());
        randomsBase64.Add(GenerateRandom.GenerateRandomBase64());

        destinoDto.Pictures = randomsBase64;

        var url = "/destinos";

        var stringContent = new StringContent(TestHelper.SerializerObjToJson(destinoDto), encoding: Encoding.UTF8, "application/json");

        //act
        var response = await client.PostAsync(url, stringContent);
       
        //assert
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    [Order(2)]
    public async Task DeverarRetornarOsDestinosCadastrados()
    {
        //arrrange
        var uri = new UriBuilder(client.BaseAddress + "destinos");
        uri.Query = $"size={10}&page={0}";

        //act
        var response = await client.GetAsync(uri.ToString());

        string content = await response.Content.ReadAsStringAsync();

        var destinos = JsonSerializer.Deserialize<List<Destino>>(content)!;

        //assert
        Assert.That(destinos, Has.Count.EqualTo(1));
    }



}
