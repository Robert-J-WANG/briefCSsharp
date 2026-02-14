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

    static void Main()
    {
        // var order = new Order();
        // order.Amount = -100; // // 金额非法
        // order.Status = "?????"; // 状态可能乱改

        // var order = new Order(100);
        //  Console.WriteLine($"the amount of the order is {order.Amount}, the status is {order.Status}");
        //  order.Pay();
        //  Console.WriteLine($"the status is {order.Status}");

        // 继承
        // var onlineOrder = new OnlineOrder(100);
        // onlineOrder.Pay();
        // Console.WriteLine($"the amount of the onlineOrder is {order.Amount}, the status is {order.Status}");
        //
        // var storeOrder = new StoreOrder(200);
        // storeOrder.Pay();
        // Console.WriteLine($"the amount of the storeOrder is {order.Amount}, the status is {order.Status}");

        // 多态的实现
        // List<Order> orders = new()
        // {
        //     new OnlineOrder(100),
        //     new StoreOrder(200)
        // };
        //
        // foreach (var order in orders)
        // {
        //     order.Pay(); // 这里调用的是子类各自的 Pay()
        // }
        
        // 接口的使用场景
        
        // var payables = new List<IPayable>()
        // {
        //     new OnlineOrder(200),
        //     new StoreOrder(300),
        //     new Invoice("123456", 9999)
        // };
        // PayAll(payables);
        
        // 使用组合+外部依赖
        var fakePaymentGateway = new FakePaymentGateway();

        var pays = new List<IPayable>()
        {
            // 继承+接口+依赖注入
            new OnlineOrder(111, fakePaymentGateway),
            // 继承+接口
            new StoreOrder(222),
            // 接口
            new Invoice("no_123456",333)
        };
        
        PayAll(pays);

        

    }
}