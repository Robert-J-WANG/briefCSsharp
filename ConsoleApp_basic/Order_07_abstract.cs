namespace ConsoleApp_basic;

public abstract class Order_07_abstract
{
    // 子类需要用到，所以 protected
    protected decimal _amount;
    protected OrderStatus _status;

    protected Order_07_abstract(decimal amount)
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
    
    // 抽象pay方法， 不给默认实现，强制子类实现
    public abstract void Pay();
    
    // 但父类依然可以提供“共享的校验工具”
    protected void EnsureCanPay()
    {
        if (_status != OrderStatus.Created)
            throw new InvalidOperationException("Only a Created order can be paid.");
    }

}