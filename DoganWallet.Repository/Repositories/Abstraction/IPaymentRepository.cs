using DoganWallet.Core.Repositories.Abstraction;
using DoganWallet.Domain.Entities;
using DoganWallet.Domain.Enums;
using DoganWallet.Repository.DbContexts;

namespace DoganWallet.Repository.Repositories.Abstraction;

public interface IPaymentRepository : IRepository<Payment, WalletDbContext>
{
    Task<IEnumerable<Payment>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Payment>> GetByWalletIdAsync(Guid walletId, CancellationToken cancellationToken = default);
    Task<Payment> GetByExternalReferenceIdAsync(string externalReferenceId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Payment>> GetByStatusAsync(PaymentStatus status, CancellationToken cancellationToken = default);
    Task<IEnumerable<Payment>> GetPendingPaymentsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Payment>> GetByTransactionIdAsync(Guid transactionId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Payment>> GetByUserIdAndDateRangeAsync(
        Guid userId, 
        DateTime startDate, 
        DateTime endDate, 
        CancellationToken cancellationToken = default);
    Task<decimal> GetTotalAmountByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}