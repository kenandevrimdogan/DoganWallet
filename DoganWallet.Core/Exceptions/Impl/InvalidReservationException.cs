namespace DoganWallet.Core.Exceptions.Impl;

public class InvalidReservationException : DomainException
{
    public InvalidReservationException(string message) : base(message) { }
}
