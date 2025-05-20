namespace ChatBot.Services.ApiChatBot.Services;

public class ChatBotService(
    IOllamaApiClient ollamaApiClient,
    IChatCompletionService chatCompletionService,
    ITextGenerationService textGenerationService
    ) : IChatBotService
{

    private readonly string prompt = $"{PromptChat.SystemPrompt}:";

    public async ValueTask<IEnumerable<Model>> GetModelsAsync()
    {
        return await ollamaApiClient.ListLocalModelsAsync();
    }

    public async IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(
        MessageCompletion request,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var newPrompt = prompt + request.message;
        await foreach (var response in chatCompletionService.GetStreamingChatMessageContentsAsync(
            newPrompt,
            new PromptExecutionSettings { ModelId = request.model },
            null,
            cancellationToken))
        {
            yield return response;
        }
    }

    public async IAsyncEnumerable<StreamingTextContent> GetTextContentsAsync(
        MessageCompletion request,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
          var newPrompt = prompt + request.message;
        await foreach (var response in textGenerationService.GetStreamingTextContentsAsync(
            newPrompt,
            new PromptExecutionSettings { ModelId = request.model },
            null,
            cancellationToken))
        {
            yield return response;
        }
    }
}