using Microsoft.SemanticKernel.ChatCompletion;

namespace ChatBot.Services.ApiChatBot.DI;

public static class ApplicationServiceDI
{
    public static IServiceCollection AddServiceDIInjection(this IServiceCollection services)
    {
        services.AddScoped<IChatCompletionService, IChatCompletionService>();
        return services;
    }
}