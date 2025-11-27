namespace DoganWallet.Event.Events.ReservationCommittedEvent;

public class ReservationCommittedEvent : IntegrationEvent
{
    public Guid ReservationId { get; set; }
    public Guid WalletId { get; set; }
    public Guid TransactionId { get; set; }
    public decimal Amount { get; set; }
}