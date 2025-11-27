namespace DoganWallet.Event.Events.BalanceReservedEvent;

public class BalanceReservedEvent : IntegrationEvent
{
    public Guid ReservationId { get; set; }
    public Guid WalletId { get; set; }
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public string Purpose { get; set; }
}