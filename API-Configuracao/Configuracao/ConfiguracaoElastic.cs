using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;


namespace API_Configuracao.Configuracao;

public static class ConfiguracaoElastic
{
    public static void AddElasticSearch(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var defaultIndex = configuration["ElasticsearchSettings:defaultIndex"];
        var basicAuthUser = configuration["ElasticsearchSettings:username"];
        var basicAuthPassword = configuration["ElasticsearchSettings:password"];



        var settings = new ConnectionSettings(new Uri(configuration["ElasticsearchSettings:uri"]));

        if (!string.IsNullOrEmpty(defaultIndex))
            settings = settings.DefaultIndex(defaultIndex);

        if (!string.IsNullOrEmpty(basicAuthUser) && !string.IsNullOrEmpty(basicAuthPassword))
            settings = settings.BasicAuthentication(basicAuthUser, basicAuthPassword);


        

        var client = new ElasticClient(settings);

        serviceCollection.AddSingleton<IElasticClient>(client); 


    }
}
