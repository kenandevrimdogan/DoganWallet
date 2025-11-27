using DoganWallet.Core.Events.Abstraction;

namespace DoganWallet.Event;

public abstract class IntegrationEvent : IIntegrationEvent
{
    public Guid EventId { get; set; }
    public DateTime OccurredAt { get; set; }
    public int Version { get; set; }
        
    protected IntegrationEvent()
    {
        EventId = Guid.NewGuid();
        OccurredAt = DateTime.UtcNow;
        Version = 1;
    }
}