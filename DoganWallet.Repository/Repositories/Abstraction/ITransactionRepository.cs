using DoganWallet.Core.Repositories.Abstraction;
using DoganWallet.Domain.Entities;
using DoganWallet.Domain.Enums;
using DoganWallet.Repository.DbContexts;

namespace DoganWallet.Repository.Repositories.Abstraction;

public interface ITransactionRepository: IRepository<Transaction, WalletDbContext>
{
    Task<IEnumerable<Transaction>> GetByWalletIdAsync(Guid walletId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Transaction>> GetByReferenceIdAsync(string referenceId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Transaction>> GetByStatusAsync(TransactionStatus status, CancellationToken cancellationToken = default);
    Task<Transaction> GetByIdWithWalletAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Transaction>> GetRelatedTransactionsAsync(Guid transactionId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Transaction>> GetByWalletIdAndDateRangeAsync(
        Guid walletId, 
        DateTime startDate, 
        DateTime endDate, 
        CancellationToken cancellationToken = default);
}