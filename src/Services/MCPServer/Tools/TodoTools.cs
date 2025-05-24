
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
}