using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var redis = builder.AddRedis("redis");

var launchProfileName = ShouldUseHttpForEndpoints(configuration) ? "http" : "https";

var webOllama = builder.AddContainer("open-ollamaui", "ghcr.io/open-webui/open-webui", "main");
var ollama = builder.AddOllama("ollama")
.WithVolume("ollama", "/root/.ollama");
var llamaModel = ollama.AddModel("llama", "llama3.2");


var seq = builder.AddSeq("seq");

var apiChatBot = builder.AddProject<Projects.ApiChatBot>("api-chatbot", launchProfileName);

apiChatBot.WithReference(redis)
.WaitFor(llamaModel)
.WithReference(seq)
.WithReference(llamaModel)
.WithReference(ollama.GetEndpoint(launchProfileName));

var webChatBot = builder.AddNpmApp("chatbotweb", "../Frontends/chatbotweb");

webChatBot
.WithExternalHttpEndpoints()
.WithHttpEndpoint(env: "PORT")
.WithReference(apiChatBot)
.WithReference(ollama.GetEndpoint(launchProfileName))
.WithReference(seq);

webOllama
.WithVolume("open-ollamaui", "/app/data")
.WithEnvironment("WEBUI_AUTH", "False")
.WithEnvironment("OLLAMA_BASE_URL", ollama.GetEndpoint(launchProfileName))
.WithHttpEndpoint(port: 3000, targetPort: 8080);

builder.Build().Run();

static bool ShouldUseHttpForEndpoints(IConfiguration configuration)
{
    var envValue = configuration["CHATBOT_USE_HTTP_ENDPOINTS"];
    return int.TryParse(envValue, out int result) && result == 1;
}