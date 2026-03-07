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
    public static void SetLoggingConfiguration(this LoggerConfiguration loggerConfig, string environment, IConfiguration configuration)
    {
        var elasticUri = configuration["Elasticsearch:Uri"] ?? "http://localhost:9200";
        
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
                })
            .CreateLogger();
        
    }
}