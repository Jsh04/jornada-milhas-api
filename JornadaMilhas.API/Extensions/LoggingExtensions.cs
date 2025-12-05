using Elastic.Channels;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Elastic.Transport;
using Serilog;
using Serilog.Events;

namespace JornadaMilhas.API.Extensions;

public static class LoggingExtensions
{
    public static void AddLogging(this IServiceCollection services, string environment, IConfiguration configuration)
    {
        var elasticUri = configuration["Elasticsearch:Uri"] ?? "https://localhost:9200";
        
        var elasticPassword = configuration["Elasticsearch:Password"] ?? "";
        var elasticUsername = configuration["Elasticsearch:Username"] ?? "";
        
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentName()
            .Enrich.WithProperty("Application", "JornadaMilhas")
            .WriteTo.Console()
            .WriteTo.Elasticsearch(new [] { new Uri(elasticUri) },
                opts =>
                {
                    opts.DataStream = new DataStreamName(
                        "logs",           
                        "jornada-milhas",
                        environment
                    );
                    opts.BootstrapMethod = BootstrapMethod.Failure;
                    opts.ConfigureChannel = channelOpts =>
                    {
                        channelOpts.BufferOptions = new BufferOptions
                        {
                            OutboundBufferMaxSize = 5000
                        };
                    };
                }, 
                configureTransport: transportConfig =>
                {
                    transportConfig.Authentication(new BasicAuthentication(elasticUsername, elasticPassword));
                    transportConfig.RequestTimeout(TimeSpan.FromSeconds(30));
                    transportConfig.ServerCertificateValidationCallback((_, _, _, _) => true);
                })
            .CreateLogger();
        
    }
}