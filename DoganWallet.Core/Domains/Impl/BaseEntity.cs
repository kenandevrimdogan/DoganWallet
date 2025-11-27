using DoganWallet.Core.Domain.Abstraction;

namespace DoganWallet.Core.Domain.Impl;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreaUserId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid ModifUserId { get; set; }
}