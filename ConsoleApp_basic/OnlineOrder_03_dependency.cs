namespace ConsoleApp_basic;

public class OnlineOrder_03_dependency:Order
{
    public OnlineOrder_03_dependency(decimal amount) : base(amount)
    {
    }
    
    // 重写Pay()
    public override void Pay()
    {
        EnsureCanPay();
        Console.WriteLine($"[Online] Calling payment gateway, amount={_amount}");
        _status = OrderStatus.Paid;
    }
}