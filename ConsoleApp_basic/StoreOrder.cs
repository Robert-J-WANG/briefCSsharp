namespace ConsoleApp_basic;

public class StoreOrder : Order
{
    public StoreOrder(decimal amount) : base(amount)
    {
    }

    // 重写Pay()
    public override void Pay()
    {
        EnsureCanPay();
        Console.WriteLine($"[Store] Cash received at counter, amount={_amount}");
        _status = OrderStatus.Paid;
    }
}