namespace DoganWallet.Core.Exceptions.Impl;

public class WalletNotFoundException : DomainException
{
    public WalletNotFoundException(Guid walletId) 
        : base($"Wallet with ID {walletId} not found") { }
}