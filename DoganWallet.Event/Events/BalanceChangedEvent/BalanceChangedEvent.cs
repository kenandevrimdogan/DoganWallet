namespace DoganWallet.Event.Events.BalanceChangedEvent;

public class BalanceChangedEvent : IntegrationEvent
{
    public Guid WalletId { get; set; }
    public Guid UserId { get; set; }
    public decimal OldBalance { get; set; }
    public decimal NewBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public string Reason { get; set; }
    public Guid TransactionId { get; set; }
}