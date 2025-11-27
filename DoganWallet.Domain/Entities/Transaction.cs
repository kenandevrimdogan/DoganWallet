using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoganWallet.Core.Domain.Impl;
using DoganWallet.Domain.Enums;

namespace DoganWallet.Domain.Entities;

[Table("Transaction", Schema = "transaction")]
public class Transaction : BaseEntity
{
    public Guid WalletId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public string Description { get; set; }
    public string ReferenceId { get; set; }
    public Guid? RelatedTransactionId { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string Metadata { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    
    public virtual Wallet Wallet { get; set; }
}