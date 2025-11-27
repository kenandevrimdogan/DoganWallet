using DoganWallet.Domain.Entities;
using DoganWallet.Repository.DbContexts;
using DoganWallet.Repository.Repositories.Abstraction;
using DoganWallet.Core.Repositories.Impl;
using DoganWallet.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DoganWallet.Repository.Repositories.Impl;

public class PaymentRepository : Repository<Payment, WalletDbContext>, IPaymentRepository
{
    public PaymentRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Payment>> GetByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Payment>> GetByWalletIdAsync(
        Guid walletId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(p => p.WalletId == walletId)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Payment> GetByExternalReferenceIdAsync(
        string externalReferenceId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FirstOrDefaultAsync(p => p.ExternalReferenceId == externalReferenceId, cancellationToken);
    }

    public async Task<IEnumerable<Payment>> GetByStatusAsync(
        PaymentStatus status,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(t => t.Status == status)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Payment>> GetPendingPaymentsAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(p => p.Status == PaymentStatus.Pending || p.Status == PaymentStatus.Processing)
            .OrderBy(p => p.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Payment>> GetByTransactionIdAsync(
        Guid transactionId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(p => p.TransactionId == transactionId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Payment>> GetByUserIdAndDateRangeAsync(
        Guid userId,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(p =>
                p.UserId == userId &&
                p.CreatedAt >= startDate &&
                p.CreatedAt <= endDate)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<decimal> GetTotalAmountByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(p => p.UserId == userId && p.Status == PaymentStatus.Completed)
            .SumAsync(p => p.Amount, cancellationToken);
    }
}