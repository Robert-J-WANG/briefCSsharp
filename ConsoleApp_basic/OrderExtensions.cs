namespace ConsoleApp_basic;

public static class OrderExtensions
{

    public static Order AddSuccessHandlers(this Order order, Action<Order> handler)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (handler == null) throw new ArgumentNullException(nameof(handler));
        order.OnSuccess += handler;
        return order;
    }

    
    // ✅ 把“支付”也包装成扩展方法：返回 order 以便链式继续
    public static Order PayNow(this Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        {
            order.Pay();
        }
        return order;
    }

    // 支付后再执行一个动作（再次用 Action<Order>)
    public static Order PayAfter(this Order order, Action<Order> afterPay)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (afterPay == null) throw new ArgumentNullException(nameof(afterPay));
        if (order.Status != OrderStatus.Paid) throw new InvalidOperationException("Order  is not Paid");
        afterPay(order);
        return order;
    }
    
    /*
    public static Order AddDefaultSuccessHandlers(this Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        order.OnSuccess += (o) => Console.WriteLine($"[Log] Order paid, amount={o.Amount}");
        order.OnSuccess += (o) => Console.WriteLine($"[SendEmail] Order paid, amount={o.Amount}");
        order.OnSuccess += (o) => Console.WriteLine($"[ReduceStock] Order paid, amount={o.Amount}");

        return order;
    }
    */
    
    /*
    public static Order AddLogHandlers(this Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        order.OnSuccess += (o) => Console.WriteLine($"[Log] Order paid, amount={o.Amount}");
        return order;
    }
    
    public static Order SendEmailHandlers(this Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        order.OnSuccess += (o) => Console.WriteLine($"[SendEmail] Order paid, amount={o.Amount}");
        return order;
    }
    
    public static Order ReduceStockHandlers(this Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        order.OnSuccess += (o) => Console.WriteLine($"[ReduceStock] Order paid, amount={o.Amount}");
        return order;
    }
    */

}