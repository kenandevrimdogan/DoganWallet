namespace DoganWallet.Domain.Enums;

public enum TransactionStatus
{
    Pending = 1,
    Reserved = 2,
    Completed = 3,
    Failed = 4,
    Cancelled = 5,
    Reversed = 6
}