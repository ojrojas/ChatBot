using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using OllamaSharp;
using OllamaSharp.Models;
using Serilog;

namespace ChatBot.Services.ApiChatBot.Apis;
public static class ChatCompletionApi
{
    public static RouteGroupBuilder ChatCompletionEndpointV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty);

        api.MapPost("/api/chat", ChatCompletion).WithName("ChatBotCompletion").WithOpenApi();
        api.MapGet("/api/models", GetModels).WithName("ChatBotModels").WithOpenApi();


        return api;

        static async ValueTask<IEnumerable<Model>> GetModels(
            HttpContext context,
            IOllamaApiClient apiClient
        )
        {
            return await apiClient.ListLocalModelsAsync();
        }

        static async IAsyncEnumerable<StreamingChatMessageContent> ChatCompletion(
            HttpContext context,
            [FromBody] MessageCompletion request,
            [FromServices] IChatCompletionService chatCompletionService)
        {
            Log.Logger.Information("Request message sended");
            var prompt = $"{PromptChat.SystemPrompt}: {request.message}";

            await foreach (var result in chatCompletionService.GetStreamingChatMessageContentsAsync(prompt))
            {
                yield return result;
            }
        }

    }
}