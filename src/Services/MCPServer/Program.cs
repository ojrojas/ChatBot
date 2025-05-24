using ChatBot.Services.MCPServer.Data;
using ChatBot.Services.MCPServer.Interfaces;
using ChatBot.Services.MCPServer.Repository;
using ChatBot.Services.MCPServer.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMcpServer()
.WithHttpTransport()
.WithTools<TodoTools>();

builder.AddNpgsqlDbContext<TodoDbContext>("todoDb");
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<ITodoToolService, TodoToolService>();

builder.AddSeqEndpoint("seq");
builder.Services.AddSerilog();
builder.Services.AddLogging(options =>
{
    options.AddSeq();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider;

    var context = service.GetRequiredService<TodoDbContext>();
    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();
}

app.MapMcp();

await app.RunAsync();
