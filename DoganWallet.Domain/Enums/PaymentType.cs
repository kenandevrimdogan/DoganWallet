namespace DoganWallet.Domain.Enums;

public enum PaymentType
{
    CreditCard = 1,
    DebitCard = 2,
    BankTransfer = 3,
    Wallet = 4,         // Wallet'tan direkt ödeme
    QRCode = 5,
    Cash = 6
}