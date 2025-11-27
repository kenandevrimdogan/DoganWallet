namespace DoganWallet.Core.Domain.Abstraction;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreatedAt { get; set; }
    Guid CreaUserId { get; set; }
    DateTime UpdatedAt { get; set; }
    Guid ModifUserId { get; set; }
}