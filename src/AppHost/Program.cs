using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var launchProfileName = ShouldUseHttpForEndpoints(configuration) ? "http" : "https";

var ollama = builder.AddOllama("ollama")
.WithVolume("ollama-store", "/root/.ollama").WithOpenWebUI();

var llamaModel = ollama.AddModel("llama", "qwen2.5-coder:3b");

var postgres = builder.AddPostgres("postgres")
.WithImage("ankane/pgvector")
    .WithImageTag("latest").WithPgAdmin();

var todoDb = postgres.AddDatabase("todoDb");


var seq = builder.AddSeq("seq");

var apiChatBot = builder.AddProject<Projects.ApiChatBot>("api-chatbot", launchProfileName);
var mcpServer = builder.AddProject<Projects.MCPServer>("mcpServer", launchProfileName);
var mpcInspector = builder.AddNpmApp("mcp-inspector", "../Frontends/inspector");

mpcInspector.WithHttpEndpoint(env: "PORT")
.WithReference(mcpServer);

mcpServer
.WaitFor(todoDb)
.WithReference(todoDb)
.WithReference(seq);

apiChatBot
.WaitFor(llamaModel)
.WaitFor(mcpServer)
.WithReference(seq)
.WithReference(llamaModel)
.WithReference(mcpServer)
.WithEnvironment("MCPServer", mcpServer.GetEndpoint(launchProfileName))
.WithReference(ollama.GetEndpoint(launchProfileName));

var webChatBot = builder.AddNpmApp("chatbotweb", "../Frontends/chatbotweb");

webChatBot
.WithExternalHttpEndpoints()
.WithHttpEndpoint(env: "PORT")
.WithReference(apiChatBot)
.WithReference(ollama.GetEndpoint(launchProfileName))
.WithReference(seq);

builder.Build().Run();

static bool ShouldUseHttpForEndpoints(IConfiguration configuration)
{
    var envValue = configuration["CHATBOT_USE_HTTP_ENDPOINTS"];
    return int.TryParse(envValue, out int result) && result == 1;
}