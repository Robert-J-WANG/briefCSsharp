namespace ConsoleApp_basic;

public class OnlineOrder : Order
{
    private IPaymentGateway _gateway;
    public OnlineOrder(decimal amount,IPaymentGateway gateway) : base(amount)
    {
        _gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));
    }
    
    // 重写Pay()
    public override void Pay()
    {
        EnsureCanPay();
        // Console.WriteLine($"[Online] Calling payment gateway, amount={_amount}");
        // 外部依赖的变化点，交给 gateway 处理
        _gateway.Charge(_amount);
        _status = OrderStatus.Paid;
        
    }
}