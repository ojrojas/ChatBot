using ChatBot.Services.ApiChatBot.Models;

namespace ChatBot.Services.ApiChatBot.Dtos;

public record CreateWorkspaceResponse
{
    Workspace workspaceCreated { get; set; }
}