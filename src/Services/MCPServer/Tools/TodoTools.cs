using System.ComponentModel;
using ChatBot.Services.MCPServer.Interfaces;
using ChatBot.Services.MCPServer.Models;
using ModelContextProtocol.Server;

[McpServerToolType]
internal sealed class TodoTools(ILogger<TodoTools> logger, ITodoToolService todoToolService)
{
    private readonly ITodoToolService _todoToolService = todoToolService ?? throw new ArgumentNullException(nameof(todoToolService));
    private readonly ILogger<TodoTools> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    [McpServerTool, Description("Create todo item.")]
    public async ValueTask<Todo> CreateTodo(Todo todo, CancellationToken cancellationToken)
    {
        return await _todoToolService.CreateTodoAsync(todo, cancellationToken);
    }

    [McpServerTool, Description("Get all todo items")]
    public async ValueTask<IEnumerable<Todo>> GetAllTodo(CancellationToken cancellationToken)
    {
        return await _todoToolService.GetAllTodoAsync(cancellationToken);
    }

    [McpServerTool, Description("Get todo by id item")]
    public async ValueTask<Todo> GetTodoById(Guid id, CancellationToken cancellationToken)
    {
        return await _todoToolService.GetTodoByIdAsync(id, cancellationToken);
    }

    [McpServerTool, Description("Update todo by id item")]
    public async ValueTask<Todo> UpdateTodo(Guid id, Todo todo, CancellationToken cancellationToken)
    {
        return await _todoToolService.UpdateTodoAsync(id, todo, cancellationToken);
    }

    [McpServerTool, Description("Delete todo by id item")]
    public async ValueTask<bool> DeleteTodo(Guid id, CancellationToken cancellationToken)
    {
        return await _todoToolService.DeleteTodoByIdAsync(id, cancellationToken);
    }
}