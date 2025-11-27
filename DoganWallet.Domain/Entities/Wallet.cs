using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoganWallet.Core.Domain.Impl;

namespace DoganWallet.Domain.Entities;

[Table("Wallet", Schema = "wallet")]
public class Wallet : BaseEntity
{
    public Guid UserId { get; set; }
    public decimal Balance { get; set; }
    public decimal ReservedBalance { get; set; }
    public string Currency { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; }
}