using System.Text.Json;
using System.Text.Json.Serialization;
using ChatBot.Services.MCPServer.Interfaces;
using ChatBot.Services.MCPServer.Models;
using StackExchange.Redis;

namespace ChatBot.Services.MCPServer.Repository
{
    public class TodoRepository(ILogger<TodoRepository> logger, IConnectionMultiplexer redis) : ITodoRepository
    {
        private readonly IDatabase database = redis.GetDatabase();

        private static readonly RedisKey TodoKeyPrefix = "/todo/"u8.ToArray();
        private readonly ILogger<TodoRepository> logger = logger;

        private static RedisKey GetTodoKey(Guid userId) => TodoKeyPrefix.Append(userId.ToString());

        public async ValueTask<Todo> UpdateTodoAsync(Guid Id, Todo todo, CancellationToken cancellationToken)
        {
            var json = JsonSerializer.SerializeToUtf8Bytes(todo, TodoSerializationContext.Default.Todo);
            var created = await database.StringSetAsync(GetTodoKey(todo.Id), json);

            if (!created)
            {
                logger.LogInformation("Problem occurred persisting the item.");
                return null;
            }

            logger.LogInformation("Todo item persisted successfully.");
            return await GetTodoByIdAsync(todo.Id, cancellationToken);
        }

        public async ValueTask<Todo> GetTodoByIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            using var data = await database.StringGetLeaseAsync(GetTodoKey(Id));

            if (data is null || data.Length == 0)
                return null;

            return JsonSerializer.Deserialize(data.Span, TodoSerializationContext.Default.Todo);
        }

        public async ValueTask<Todo> GetAllTodoAsync(CancellationToken cancellationToken)
        {
            using var data = await database.StringGetLeaseAsync(TodoKeyPrefix);

            if (data is null || data.Length == 0)
                return null;

            return JsonSerializer.Deserialize(data.Span, TodoSerializationContext.Default.Todo);
        }

        public async ValueTask<bool> DeleteTodoByIdAsync(Guid Id, Todo todo, CancellationToken cancellationToken)
        {
            return await database.KeyDeleteAsync(GetTodoKey(Id));
        }
    }

    [JsonSerializable(typeof(Todo))]
    [JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
    public partial class TodoSerializationContext : JsonSerializerContext
    {
    }
}