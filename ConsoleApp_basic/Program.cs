namespace ConsoleApp_basic;

class Program
{
    /*
     * 统一处理支付的方法
     */
    static void PayAll(IEnumerable<IPayable> payables)
    {
        foreach (var p in payables)
            p.Pay();
    }


    // static void LogPaid(Order order)
    // {
    //     Console.WriteLine($"[Log] Order paid, amount={order.Amount}");
    // }
    //
    // static void SendEmail(Order order)
    // {
    //     Console.WriteLine($"[SendEmail] Order paid, amount={order.Amount}");
    // }
    //
    // static void ReduceStock(Order order)
    // {
    //     Console.WriteLine($"[ReduceStock] Order paid, amount={order.Amount}");
    // }



    static void Main()
    {
        // 使用组合+外部依赖
        var fakePaymentGateway = new FakePaymentGateway();

        var onlineOrder = new OnlineOrder(123456, fakePaymentGateway);


        // 赋值 - 事件无法直接赋值
        // onlineOrder.OnSuccess = (order)=>Console.WriteLine($"[Log] Order paid, amount={order.Amount}");
        
        // 订阅 - 追加
        onlineOrder.OnSuccess += (order)=>Console.WriteLine($"[SendEmail] Order paid, amount={order.Amount}");
        onlineOrder.OnSuccess += (order)=>Console.WriteLine($"[ReduceStock] Order paid, amount={order.Amount}");
        // 取消 - 移除
        onlineOrder.OnSuccess -= (order)=>Console.WriteLine($"[Log] Order paid, amount={order.Amount}");
        
        // 事件无法直接清空
        // onlineOrder.OnSuccess = null; 

        onlineOrder.Pay();
        
        /*
        // 赋值 - 挂载委托回调
        onlineOrder.OnSuccess = (order)=>Console.WriteLine($"[Log] Order paid, amount={order.Amount}");
        
        // 订阅 - 追加
        onlineOrder.OnSuccess += (order)=>Console.WriteLine($"[SendEmail] Order paid, amount={order.Amount}");
        onlineOrder.OnSuccess += (order)=>Console.WriteLine($"[ReduceStock] Order paid, amount={order.Amount}");
        // 取消 - 移除
        onlineOrder.OnSuccess -= (order)=>Console.WriteLine($"[Log] Order paid, amount={order.Amount}");

        onlineOrder.Pay();
        */


        /*
        // 赋值 - 挂载委托回调
        onlineOrder.OnSuccess = LogPaid;
        // 订阅 - 追加
        onlineOrder.OnSuccess += SendEmail;
        onlineOrder.OnSuccess+=ReduceStock;
        // 取消 - 移除
        onlineOrder.OnSuccess -= LogPaid;

        onlineOrder.Pay();
        */


        // onlineOrder.SetSuccessHandler(LogPaid);
        // onlineOrder.AddSuccessHandler(SendEmail);
        // onlineOrder.AddSuccessHandler(ReduceStock);
        // onlineOrder.RemoveSuccessHandler(LogPaid);
        // onlineOrder.ClearSuccessHandler();
        // onlineOrder.Pay();


        // var pays = new List<IPayable>()
        // {
        //     // 继承+接口+依赖注入
        //     new OnlineOrder(111, fakePaymentGateway),
        //     // 继承+接口
        //     new StoreOrder(222),
        //     // 接口
        //     new Invoice("no_123456",333)
        // };
        //
        // PayAll(pays);
    }
}