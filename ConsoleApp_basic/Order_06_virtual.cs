namespace ConsoleApp_basic;

public class Order_06_virtual
{
    // 子类需要用到，所以 protected
    protected decimal _amount;
    protected OrderStatus _status;

    public Order_06_virtual(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount must be greater than 0.", nameof(amount));
        }

        _amount = amount;
        _status = OrderStatus.Created;
    }

    public decimal Amount => _amount;
    public OrderStatus Status => _status;
    
    // 允许子类改写支付逻辑
    public virtual void Pay()
    {
        if (_status != OrderStatus.Created)
        {
            throw new InvalidOperationException("Only created orders can be paid.");
        }

        _status = OrderStatus.Paid;
    }
}