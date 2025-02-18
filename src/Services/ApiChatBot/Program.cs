using BolunderErp.BuildingBlocks.Loggers;
using ChatBot.BuildingBlocks.Loggers;
using ChatBot.BuildingBlocks.ServiceDefaults;
using ChatBot.Services.ApiChatBot;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.TextGeneration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

var kernel = builder.Services.AddKernel();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();
builder.AddServiceDefaults();
builder.AddServicesWritersLogger();

Log.Logger = LoggerPrinter.CreateSerilogLogger("api", "apichatbot", configuration);

var connectionString = builder.Configuration.GetConnectionString("llama");
var ollamaConnection = new OllamaConnection(connectionString);

#pragma warning disable SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
kernel.AddOllamaTextGeneration(ollamaConnection.Model, new Uri(ollamaConnection.Endpoint));
#pragma warning restore SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/chat", async (
    MessageCompletion request,
     ITextGenerationService textGenerationService) =>
{
    try
    {
        var prompt = $"Obtain the antonyms and synonyms of the following sentence: {request.message}";
        return await textGenerationService.GetTextContentsAsync(prompt);
    }
    catch (Exception ex)
    {

        throw new Exception(ex.Message, ex);
    }
})
.WithName("ChatBotExample")
.WithOpenApi();

app.Run();