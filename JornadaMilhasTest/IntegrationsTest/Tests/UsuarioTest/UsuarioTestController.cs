using System.Text;
using AutoFixture;
using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhasTest.IntegrationsTest.Helper;

namespace JornadaMilhasTest.IntegrationsTest.Tests.UsuarioTest;

[TestFixture]
[Explicit("Testes de integração")]
[Category("IntegrationTest")]
public class UsuarioTestController
{
    private readonly HttpClient _client;
    private readonly Fixture fixture;
    private readonly string EndPoint = "api/v1/";

    public UsuarioTestController()
    {
        _client = SharingResources.Fixture.client;
        fixture = new Fixture();
    }

    [Test(Description = "Devera retornar o dados cadastrados do usuario")]
    public async Task TestarRetornoDoCadastroDeUsuario()
    {
        var usuario = fixture.Create<RegisterUserLimitedCommand>();
        string url = EndPoint + "userLimited";


        var stringContent = new StringContent(TestHelper.SerializerObjToJson(usuario), encoding: Encoding.UTF8, TestHelper.ContentTypeJson);
        var response = await _client.PostAsync(url, stringContent);

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        StringAssert.Contains("text/html; charset=utf-8",
            response.Content.Headers.ContentType.ToString());
    }
}

