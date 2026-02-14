namespace ConsoleApp_basic;

public class StoreOrder_02_override: Order
{
    public StoreOrder_02_override(decimal amount) : base(amount)
    {
    }

    // 重写Pay()
    public override void Pay()
    {
        if (_status != OrderStatus.Created)
            throw new InvalidOperationException("Only a Created order can be paid.");

        Console.WriteLine($"[Store] Cash received at counter, amount={_amount}");
        _status = OrderStatus.Paid;
    }
}