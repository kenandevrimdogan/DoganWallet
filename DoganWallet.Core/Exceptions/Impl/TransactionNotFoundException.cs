namespace DoganWallet.Core.Exceptions.Impl;

public class TransactionNotFoundException : DomainException
{
    public TransactionNotFoundException(Guid transactionId) 
        : base($"Transaction with ID {transactionId} not found") { }
}