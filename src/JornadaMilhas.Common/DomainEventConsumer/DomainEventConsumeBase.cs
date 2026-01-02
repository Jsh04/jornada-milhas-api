namespace JornadaMilhas.Common.DomainEventConsumer;

public abstract class DomainEventConsumeBase
{
    public Guid Id { get; protected set; }

    public TimeSpan Time { get; protected set; }

    public DateTime DtEvent { get; protected set; }
}