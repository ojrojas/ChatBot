using ChatBot.Services.MCPServer.Data;
using ChatBot.Services.MCPServer.Interfaces;
using ChatBot.Services.MCPServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.Services.MCPServer.Repository
{
    public class TodoRepository(ILogger<TodoRepository> logger, TodoDbContext context) : ITodoRepository
    {
        private readonly TodoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<TodoRepository> logger = logger;

        public async ValueTask<Todo> UpdateTodoAsync(Guid id, Todo todo, CancellationToken cancellationToken)
        {
            var itemToUpdate = await GetTodoByIdAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(itemToUpdate);
            itemToUpdate.Descriptions = todo.Descriptions;
            itemToUpdate.IsDone = todo.IsDone;
            itemToUpdate.DoneOn = todo.DoneOn;

            var entity = _context.Todos.Update(itemToUpdate);
            if (await _context.SaveChangesAsync(cancellationToken) > 0)
                return entity.Entity;
            else return null;
        }

        public async ValueTask<Todo> GetTodoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Todos.FindAsync(new object[] { id }, cancellationToken);
        }

        public async ValueTask<IEnumerable<Todo>> GetAllTodoAsync(CancellationToken cancellationToken)
        {
            return await _context.Todos.ToListAsync();
        }

        public async ValueTask<bool> DeleteTodoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var todoToRemoved = await GetTodoByIdAsync(id, cancellationToken);
            var result = _context.Todos.Remove(todoToRemoved).Entity != null;
            await _context.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async ValueTask<Todo> CreateTodoAsync(Todo todo, CancellationToken cancellationToken)
        {
            var entity = await _context.Todos.AddAsync(todo, cancellationToken);
            if (await _context.SaveChangesAsync(cancellationToken) > 0)
                return entity.Entity;
            else return null;
        }
    }
}