using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace API_Infraestrutura.Configuracao;

public static class ConfiguracaoElastic
{
    public static ElasticsearchClient CreateElasticCLient()
    {
        var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
            .CertificateFingerprint("")
            .Authentication(new BasicAuthentication("elastic", ""));

        var client = new ElasticsearchClient(settings);

        return client;
    }
}
