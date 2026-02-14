namespace ConsoleApp_basic;

public class FakePaymentGateway:IPaymentGateway
{
    public void Charge(decimal amount)
    {
        Console.WriteLine($"[Gateway] Charged amount={amount}");
    }
}