using ChatBot.Services.MCPServer.Interfaces;
using ChatBot.Services.MCPServer.Models;

namespace ChatBot.Services.MCPServer.Services;

public class TodoToolService(ILogger<TodoToolService> logger, ITodoRepository todoRepository) : ITodoToolService
{
    readonly ILogger<TodoToolService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    readonly ITodoRepository _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));

    public async ValueTask<bool> DeleteTodoByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _todoRepository.DeleteTodoByIdAsync(Id, cancellationToken);
    }

    public async ValueTask<IEnumerable<Todo>> GetAllTodoAsync(CancellationToken cancellationToken)
    {
        return await _todoRepository.GetAllTodoAsync(cancellationToken);
    }

    public async ValueTask<Todo> GetTodoByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _todoRepository.GetTodoByIdAsync(Id, cancellationToken);
    }

    public async ValueTask<Todo> UpdateTodoAsync(Todo todo, CancellationToken cancellationToken)
    {
        return await _todoRepository.UpdateTodoAsync(todo, cancellationToken);
    }
}