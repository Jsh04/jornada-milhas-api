using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System;
namespace API_Infraestrutura.Configuracao;

public static class FactoryElastic
{
    public static ElasticsearchClient CreateElasticCLient()
    {
        var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
            .CertificateFingerprint("2c75cd2b69483e3bd090238a8c4a1ba922d7e68143be3d9f05382d49f38ce723")
            .Authentication(new BasicAuthentication("elastic", "GmtGF8u=Gig*LxhiNpJb"));

        

        var client = new ElasticsearchClient(settings);

        return client;
    }
}
