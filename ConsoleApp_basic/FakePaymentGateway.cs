namespace ConsoleApp_basic;

public class FakePaymentGateway : IPaymentGateway
{
    public decimal LastChargedAmount { get; private set; }
    public int CallCount { get; private set; }

    public void Charge(decimal amount)
    {
        CallCount++;
        LastChargedAmount = amount;
        Console.WriteLine($"[FakeGateway] Pretend charge {amount}");
    }
}