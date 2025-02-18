using Microsoft.Extensions.Logging;

namespace ChatBot.BuildingBlocks.Loggers;

public interface ILoggerApplicationService<T>
{
    void LogError(Guid correlationId, string message);
    void LogError(string correlationId, string message);
    void LogError(string message);

    void LogInformation(Guid correlationId, string message);
    void LogInformation(string correlationId, string message);
    void LogInformation(string message);

    void LogWarning(Guid correlationId, string message);
    void LogWarning(string correlationId, string message);
    void LogWarning(string message);

    void LogDebug(Guid correlationId, string message);
    void LogDebug(string correlationId, string message);
    void LogDebug(string message);

    ILogger<T> FeaturesLogger();
}