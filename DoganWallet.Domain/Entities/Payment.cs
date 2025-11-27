using DoganWallet.Core.Domain.Impl;
using DoganWallet.Domain.Enums;

namespace DoganWallet.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid WalletId { get; set; }
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public PaymentStatus Status { get; set; }
    public PaymentType Type { get; set; }
    public string Description { get; set; }
    public string ExternalReferenceId { get; set; }
    public Guid? TransactionId { get; set; }
    public string PaymentMethodId { get; set; }
    public string ErrorMessage { get; set; }
    public DateTime? ProcessedAt { get; set; }
    public string Metadata { get; set; }
}