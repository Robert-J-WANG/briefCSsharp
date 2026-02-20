namespace ConsoleApp_basic;

public class OrderService
{
    private readonly Repository<Order> _repo;
    private readonly OrderEmailNotifier _emailNotifier;
    
    //依赖注入支付通知
    public OrderService(Repository<Order> repo,  OrderEmailNotifier emailNotifier)
    {
        _repo = repo??throw new ArgumentNullException(nameof(repo));
        _emailNotifier = emailNotifier ?? throw new ArgumentNullException(nameof(emailNotifier));
    }

    public void PayOrder(int id)
    {
        var order = _repo.GetById(id).Value;
        if(order == null) throw new InvalidOperationException("Order not found");
        order.Pay();
        // 支付通知
        _emailNotifier.NotifyPaid(order);
    }
}