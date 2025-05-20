namespace ChatBot.Services.ApiChatBot.DI;

public static class ApplicationServiceDI
{
    public static IServiceCollection AddServiceDIInjection(this IServiceCollection services, OllamaConnection connection)
    {
        services.AddKeyedSingleton<IOllamaApiClient>(null, implementationFactory: (provider, _) => {
             var loggerFactory = provider.GetService<ILoggerFactory>();

            ArgumentNullException.ThrowIfNull(connection.Endpoint);
            ArgumentNullException.ThrowIfNull(connection.Model);

            var builder = ((IChatClient)new OllamaApiClient(connection.Endpoint, connection.Model))
                .AsBuilder()
                .UseFunctionInvocation(loggerFactory, config => config.MaximumIterationsPerRequest = 128);

            if (loggerFactory is not null)
            {
                builder.UseLogging(loggerFactory);
            }

            var client =  builder.Build(provider);
            return client is OllamaApiClient apiClient ? apiClient : new OllamaApiClient(connection.Endpoint, connection.Model);
        });

        services.AddTransient<IChatBotService, ChatBotService>();
        return services;
    }
}