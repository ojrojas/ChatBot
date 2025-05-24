namespace ChatBot.Services.MCPServer.Models;

public class Todo
{
    public Guid Id { get; set; }
    public required string Descriptions { get; set; }
    public DateTime CratedOn { get; set; } = DateTime.UtcNow;
    public DateTime? DoneOn { get; set; }
    public bool IsDone { get; set; } = false;
}
