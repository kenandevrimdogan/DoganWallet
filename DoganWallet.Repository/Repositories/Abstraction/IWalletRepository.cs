using DoganWallet.Core.Repositories.Abstraction;
using DoganWallet.Domain.Entities;
using DoganWallet.Repository.DbContexts;

namespace DoganWallet.Repository.Repositories.Abstraction;

public interface IWalletRepository: IRepository<Wallet, WalletDbContext>
{
    Task<Wallet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Wallet> GetByIdWithTransactionsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> HasSufficientBalanceAsync(Guid walletId, decimal amount, CancellationToken cancellationToken = default);
}