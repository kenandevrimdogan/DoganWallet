using DoganWallet.Domain.Entities;
using DoganWallet.Repository.DbContexts;
using DoganWallet.Repository.Repositories.Abstraction;
using DoganWallet.Core.Repositories.Impl;
using DoganWallet.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DoganWallet.Repository.Repositories.Impl;

public class TransactionRepository : Repository<Transaction, WalletDbContext>, ITransactionRepository
{
    public TransactionRepository(WalletDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Transaction>> GetByWalletIdAsync(
        Guid walletId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(t => t.WalletId == walletId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Transaction>> GetByReferenceIdAsync(
        string referenceId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(t => t.ReferenceId == referenceId)
            .ToListAsync(cancellationToken);
    }


    public async Task<IEnumerable<Transaction>> GetByStatusAsync(
        TransactionStatus status,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(t => t.Status == status)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Transaction> GetByIdWithWalletAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(t => t.Wallet)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Transaction>> GetRelatedTransactionsAsync(
        Guid transactionId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .OrderBy(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Transaction>> GetByWalletIdAndDateRangeAsync(
        Guid walletId,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(t =>
                t.WalletId == walletId &&
                t.CreatedAt >= startDate &&
                t.CreatedAt <= endDate)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}