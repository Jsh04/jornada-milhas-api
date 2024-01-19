using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System;
namespace API_Infraestrutura.Configuracao;

public static class FactoryElastic
{
    public static ElasticsearchClient CreateElasticCLient()
    {
        var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
            .CertificateFingerprint("09c4ded4a3422eedf8bb96f11ce8563bf4f9dc77b544e6d2e12044445903e91e")
            .Authentication(new BasicAuthentication("elastic", "jw4cGAQFFS74oQO3dpP4"));

        var client = new ElasticsearchClient(settings);

        return client;
    }
}
