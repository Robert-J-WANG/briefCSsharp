namespace ConsoleApp_basic;

public class RealPaymentGateway : IPaymentGateway
{
    public void Charge(decimal amount)
        => Console.WriteLine($"[RealGateway] Charged {amount}");
}