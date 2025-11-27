namespace DoganWallet.Event.Events.PaymentCompletedEvent;

public class PaymentCompletedEvent : IntegrationEvent
{
    public Guid PaymentId { get; set; }
    public Guid WalletId { get; set; }
    public Guid UserId { get; set; }
    public Guid TransactionId { get; set; }
    public decimal Amount { get; set; }
    public bool IsSuccessful { get; set; }
    public string FailureReason { get; set; }
}