
using System.ComponentModel;
using ChatBot.Services.MCPServer.Interfaces;
using ChatBot.Services.MCPServer.Models;
using ModelContextProtocol.Server;

[McpServerToolType]
internal sealed class TodoTools(ILogger<TodoTools> logger, ITodoToolService todoToolService)
{
    private readonly ITodoToolService _todoToolService = todoToolService ?? throw new ArgumentNullException(nameof(todoToolService));
    private readonly ILogger<TodoTools> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    [McpServerTool, Description("Create or update todo item.")]
    public async ValueTask<Todo> CreateOrUpdateTodo(Todo todo, CancellationToken cancellationToken)
    {
        return await _todoToolService.UpdateTodoAsync(todo, cancellationToken);
    }

    [McpServerTool, Description("Get all todo items")]
    public async ValueTask<IEnumerable<Todo>> GetAllTodo(CancellationToken cancellationToken)
    {
        return await _todoToolService.GetAllTodoAsync(cancellationToken);
    }

    [McpServerTool, Description("Get todo by id item")]
    public async ValueTask<Todo> GetTodoById(Guid Id, CancellationToken cancellationToken)
    {
        return await _todoToolService.GetTodoByIdAsync(Id, cancellationToken);
    }
}