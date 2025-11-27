namespace DoganWallet.Domain.Enums;

public enum PaymentStatus
{
    Pending = 1,        // Ödeme başlatıldı
    Processing = 2,     // İşleniyor
    Authorized = 3,     // Onaylandı (henüz capture edilmedi)
    Captured = 4,       // Para çekildi
    Completed = 5,      // Tamamlandı
    Failed = 6,         // Başarısız
    Cancelled = 7,      // İptal edildi
    Refunded = 8,       // İade edildi
    PartialRefund = 9   // Kısmi iade
}