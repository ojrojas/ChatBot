using ChatBot.Services.MCPServer.Models;

namespace ChatBot.Services.MCPServer.Interfaces;

public interface ITodoRepository
{
    ValueTask<Todo> UpdateTodoAsync(Guid Id, Todo todo, CancellationToken cancellationToken);
    ValueTask<Todo> GetTodoByIdAsync(Guid Id, CancellationToken cancellationToken);
    ValueTask<Todo> GetAllTodoAsync(CancellationToken cancellationToken);
    ValueTask<bool> DeleteTodoByIdAsync(Guid Id, Todo todo, CancellationToken cancellationToken);
}