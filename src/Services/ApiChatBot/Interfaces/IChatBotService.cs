namespace ChatBot.Services.ApiChatBot.Interfaces;

public interface IChatBotService
{
    IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(MessageCompletion request, CancellationToken cancellationToken);
    IAsyncEnumerable<StreamingTextContent>  GetTextContentsAsync(MessageCompletion request, CancellationToken cancellationToken);
    ValueTask<IEnumerable<Model>> GetModelsAsync();
}