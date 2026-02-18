namespace ConsoleApp_basic;

public enum OrderStatus
{
    Created = 0,
    Paid = 1
} 

public abstract partial class Order : IHasId
{
    private static int _nextId = 1;
    public int Id { get; } = _nextId++;
}


public abstract partial class Order: IPayable
{
    
    
    // 子类需要用到，所以 protected
    protected decimal _amount;
    protected OrderStatus _status;
    
    // 委托变成事件
    public event Action<Order> OnSuccess;

    protected Order(decimal amount)
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
    
    protected void HandlePaymentSucceeded()
    {
        // 3. 触发委托（注意：基础阶段要判断是否为 null）
        OnSuccess?.Invoke(this);
    }

}
