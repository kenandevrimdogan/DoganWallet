namespace DoganWallet.Core.Exceptions.Impl;

public class InsufficientBalanceException : DomainException
{
    public InsufficientBalanceException(string message) : base(message) { }
}