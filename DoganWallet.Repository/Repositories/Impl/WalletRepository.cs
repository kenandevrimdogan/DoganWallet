using DoganWallet.Core.Repositories.Impl;
using DoganWallet.Domain.Entities;
using DoganWallet.Repository.DbContexts;
using DoganWallet.Repository.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace DoganWallet.Repository.Repositories.Impl;

public class WalletRepository : Repository<Wallet, WalletDbContext>, IWalletRepository
{
    public WalletRepository(WalletDbContext context) 
        : base(context)
    {
    }
    
    public async Task<Wallet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FirstOrDefaultAsync(w => w.UserId == userId, cancellationToken);
    }

    public async Task<Wallet> GetByIdWithTransactionsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(w => w.Transactions.OrderByDescending(t => t.CreatedAt))
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    }

    public async Task<bool> HasSufficientBalanceAsync(
        Guid walletId, 
        decimal amount, 
        CancellationToken cancellationToken = default)
    {
        var wallet = await GetByIdAsync(walletId, cancellationToken);
        if (wallet == null)
            return false;

        var availableBalance = wallet.Balance - wallet.ReservedBalance;
        return availableBalance >= amount;
    }
}