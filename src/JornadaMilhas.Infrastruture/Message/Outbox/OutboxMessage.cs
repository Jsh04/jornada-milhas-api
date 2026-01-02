namespace JornadaMilhas.Infrastruture.Message.Outbox;

public sealed class OutboxMessage
{
    public Guid Id { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime TimeCreated { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public string? Error { get; set; }
}