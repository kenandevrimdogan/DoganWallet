namespace DoganWallet.Event.Events.PaymentInitiatedEvent;

public class PaymentInitiatedEvent : IntegrationEvent
{
    public Guid PaymentId { get; set; }
    public Guid WalletId { get; set; }
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
}