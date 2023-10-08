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
            .CertificateFingerprint("63b51a934114b5b0dfc6846391d7305a7a659658b29c364c58875dd273ab3d25")
            .Authentication(new BasicAuthentication("elastic", "pI0fNIHio3Y3Rahbrvos"));

        var client = new ElasticsearchClient(settings);

        return client;
    }
}
