namespace DoganWallet.Event.Events.ReservationReleasedEvent;

public class ReservationReleasedEvent : IntegrationEvent
{
    public Guid ReservationId { get; set; }
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; }
}