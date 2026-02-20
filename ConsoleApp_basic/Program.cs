using System.ComponentModel;
using System.Globalization;

namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        var c = new SimpleContainer();
        
        // 注册网关
        c.Register<IPaymentGateway,RealPaymentGateway>();

        // 关键：Repository<Order> 要共享同一个实例（否则内存数据不共享）
        c.Register<Repository<Order>, Repository<Order>>(Lifetime.Singleton);

        // 可选：Notifier 不注册也能创建；注册只是为了显式
        c.Register<OrderEmailNotifier, OrderEmailNotifier>(Lifetime.Transient);

        // OrderService 可选注册；不注册也能创建（具体类）
        c.Register<OrderService, OrderService>(Lifetime.Transient);

        // Order 是运行时数据（amount），仍然手动创建
        var gateway = c.Resolve<IPaymentGateway>();
        var onlineOrder = new OnlineOrder(666, gateway);

        var repo = c.Resolve<Repository<Order>>();
        repo.Add(onlineOrder);

        // 这里容器会自动注入：Repository<Order> + OrderEmailNotifier
        var orderService = c.Resolve<OrderService>();
        orderService.PayOrder(onlineOrder.Id);

        /*
        // 实例外部依赖
        var gateway = new RealPaymentGateway();
        var onlineOrder = new OnlineOrder(666, gateway);
        var repo = new Repository<Order>();
        repo.Add(onlineOrder);

        var emailNotifier = new OrderEmailNotifier();
        var orderService = new OrderService(repo, emailNotifier);
        orderService.PayOrder(onlineOrder.Id);
        */

        /*
        var onlineOrder =
            new OnlineOrder(666, gateway).AddSuccessHandlers(o => Console.WriteLine($"[Log] Paid: {o.Id} {o.Amount}"));

        var repo=new Repository<Order>();
        repo.Add(onlineOrder);

        var orderService = new OrderService(repo);
        orderService.PayOrder(onlineOrder.Id);
        */

        /*
        var order = new OnlineOrder(666, gateway);
        order.Pay();

        var fake = new FakePaymentGateway();
        var order2 = new OnlineOrder(434, fake);
        order2.Pay();

        Console.WriteLine(fake.CallCount);         // 1
        Console.WriteLine(fake.LastChargedAmount); // 100
        */
    }
}