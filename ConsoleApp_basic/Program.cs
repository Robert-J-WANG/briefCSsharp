using System.ComponentModel;
using System.Globalization;

namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        // 使用组合+外部依赖
        var fakePaymentGateway = new FakePaymentGateway();
        
        //创建订单列表
        var orders = new List<Order>()
        {
            new OnlineOrder(2234132, fakePaymentGateway),
            new StoreOrder(54624),
            new OnlineOrder(754523, fakePaymentGateway),
            new StoreOrder(3141),
            new StoreOrder(625342353),
            new StoreOrder(2314454),
            new OnlineOrder(7245, fakePaymentGateway),
            new OnlineOrder(1653735, fakePaymentGateway),
        };

        // 支付几个订单
        orders[0].Pay();
        orders[2].Pay();
        orders[3].Pay();
        orders[5].Pay();
        orders[6].Pay();
        orders[7].Pay();
        
        Console.WriteLine("=== Raw Orders ===");
        foreach (var o in orders)
        {
            Console.WriteLine($"{o.Id} {o.GetType().Name} {o.Amount} {o.Status}");
        }
        
        // 过滤（Where）——只拿已支付订单
        var paidOrders = orders.Where(o => o.Status == OrderStatus.Paid).ToList();
        
        Console.WriteLine("=== Paid Orders ===");
        foreach (var o in paidOrders)
        {
            Console.WriteLine($"{o.Id} {o.GetType().Name} {o.Amount} {o.Status}");
        }

        // 映射（Select）——把 Order 转成 OrderDto（返回模型）
        var result = paidOrders.Select(p => new OrderDto()
        {
            Id = p.Id,
            Type = p.GetType().Name,
            Amount = p.Amount,
            Status = p.Status
        }).ToList();
        
        Console.WriteLine("=== API Result (OrderDto) ===");
        foreach (var r in result)
        {
            Console.WriteLine($"{r.Id} {r.Type} {r.Amount} {r.Status}");
        }
        
        // 排序：返回结果按金额从大到小排序
        var desOrders = result.OrderByDescending(o => o.Amount).ToList();
        
        Console.WriteLine("=== API Result OrderByDescending ===");
        foreach (var r in desOrders)
        {
            Console.WriteLine($"{r.Id} {r.Type} {r.Amount} {r.Status}");
        }
        
        
        // 统计与分组（GroupBy + Count + Sum）

        var report = desOrders.GroupBy(o => o.Type).Select(r => new OrderReportItem()
        {
            Type = r.Key, // Key就是分组的依据 （这里就是Type)
            Count = r.Count(),
            TotalAmount = r.Sum(x => x.Amount)
        }).ToList();
        
        Console.WriteLine("=== Paid Orders Report ===");
        foreach (var item in report)
        {
            Console.WriteLine($"{item.Type} | Count={item.Count} | TotalAmount={item.TotalAmount}");
        }
        

        /*
        // 过滤筛选已经支付的订单金额
        var payAmounts = new List<decimal>();
        foreach (var o in orders)
        {
            if (o.Status == OrderStatus.Paid)
            {
                payAmounts.Add(o.Amount);
            }
        }
        */

        /*
        // ✅ LINQ：Where + Select + ToList
        var payAmounts = orders.Where(o => o.Status == OrderStatus.Paid).Select(o => o.Amount).ToList();

        // 循环打印出已经支付的金额
        Console.WriteLine("Paid amounts:");
        foreach (var amount in payAmounts)
        {
            Console.WriteLine(amount);
        }
        */
    }
}