using System.Data.Common;

namespace ChatBot.Services.ApiChatBot;

public record OllamaConnection(string connections)
{
    readonly DbConnectionStringBuilder connection = new ()
    {
        ConnectionString = connections
    };

    public string? Endpoint => connection["Endpoint"].ToString();
    public string? Model => connection["Model"].ToString();
}

public record MessageCompletion(string message);