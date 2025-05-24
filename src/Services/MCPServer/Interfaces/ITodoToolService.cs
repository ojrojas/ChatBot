using ChatBot.Services.MCPServer.Models;

namespace ChatBot.Services.MCPServer.Interfaces;

public interface ITodoToolService
{
    ValueTask<Todo> UpdateTodoAsync(Todo todo, CancellationToken cancellationToken);
    ValueTask<Todo> GetTodoByIdAsync(Guid Id, CancellationToken cancellationToken);
    ValueTask<IEnumerable<Todo>> GetAllTodoAsync(CancellationToken cancellationToken);
    ValueTask<bool> DeleteTodoByIdAsync(Guid Id,  CancellationToken cancellationToken);
}
