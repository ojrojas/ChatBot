using ChatBot.Services.MCPServer.Interfaces;
using ChatBot.Services.MCPServer.Models;

namespace ChatBot.Services.MCPServer.Services;

public class TodoToolService(ILogger<TodoToolService> logger, ITodoRepository todoRepository) : ITodoToolService
{
    readonly ILogger<TodoToolService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    readonly ITodoRepository _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));

    public ValueTask<Todo> CreateTodoAsync(Todo todo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Todo> DeleteTodoByIdAsync(Guid Id, Todo todo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Todo> DoneTodoAsync(Todo todo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Todo> GetAllTodoAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Todo> GetTodoByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Todo> UpdateTodoAsync(Guid Id, Todo todo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}