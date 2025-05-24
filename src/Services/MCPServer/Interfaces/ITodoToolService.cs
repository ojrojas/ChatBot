using ChatBot.Services.MCPServer.Models;

namespace ChatBot.Services.MCPServer.Interfaces;

public interface ITodoToolService
{
    ValueTask<Todo> CreateTodoAsync(Todo todo, CancellationToken cancellationToken);
    ValueTask<Todo> DoneTodoAsync(Todo todo, CancellationToken cancellationToken);
    ValueTask<Todo> UpdateTodoAsync(Guid Id, Todo todo, CancellationToken cancellationToken);
    ValueTask<Todo> GetTodoByIdAsync(Guid Id, CancellationToken cancellationToken);
    ValueTask<Todo> GetAllTodoAsync(CancellationToken cancellationToken);
    ValueTask<Todo> DeleteTodoByIdAsync(Guid Id, Todo todo, CancellationToken cancellationToken);
}
