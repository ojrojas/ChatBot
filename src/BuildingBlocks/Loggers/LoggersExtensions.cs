using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ChatBot.BuildingBlocks.Loggers;

public static class LoggersExtensions
{
    public static void AddServicesWritersLogger(this IHostApplicationBuilder builder)
    {
        builder.AddSeqEndpoint("seq");
        builder.Services.AddSerilog();
        builder.Services.AddLogging(options =>
        {
            options.AddSeq();
        });
    }
}
