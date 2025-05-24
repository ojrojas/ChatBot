namespace ChatBot.Services.ApiChatBot.Apis;

public static class ChatCompletionApi
{
    public static RouteGroupBuilder ChatCompletionEndpointV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty);

        api.MapPost("/api/chat", ChatCompletion).WithName("ChatBotCompletion").WithOpenApi();
        api.MapGet("/api/models", GetModels).WithName("ChatBotModels").WithOpenApi();
        api.MapPost("/api/generate", GenerateContent).WithName("ChatBotGenerate").WithOpenApi();

        return api;
    }

    static async ValueTask<IEnumerable<Model>> GetModels([FromServices] IChatBotService service)
    {
        return await service.GetModelsAsync();
    }

    static async IAsyncEnumerable<StreamingChatMessageContent> ChatCompletion(
        HttpContext context,
        [FromBody] MessageCompletion request,
        [FromServices] IChatBotService service, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        Log.Logger.Information("Request message sended");
        
        await foreach (var response in service.GetStreamingChatMessageContentsAsync(request, cancellationToken))
        {
            yield return response;
        }
    }

    private static async IAsyncEnumerable<StreamingTextContent> GenerateContent(
        [FromBody] MessageCompletion request,
        [FromServices] IChatBotService service,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        Log.Logger.Information("Request message sended");

        await foreach (var response in service.GetTextContentsAsync(request, cancellationToken))
        {
            yield return response;
        }
    }
}