namespace DoganWallet.Core.Events.Abstraction;

public interface IIntegrationEvent
{
    Guid EventId { get; }
    DateTime OccurredAt { get; }
    int Version { get; }
}