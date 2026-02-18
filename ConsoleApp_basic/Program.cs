using System.ComponentModel;
using System.Globalization;

namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        // 使用组合+外部依赖
        var fakePaymentGateway = new FakePaymentGateway();
        
       
        var nRepo = new Repository<Order>();
        nRepo.Add(new OnlineOrder(999, fakePaymentGateway));
        nRepo.Add(new OnlineOrder(888, fakePaymentGateway));
        var res=nRepo.GetById(1);
        Console.WriteLine(res.IsSuccess);
        Console.WriteLine(res.Value?.Amount);
        

        var order = new StoreOrder(123);
        var orderDto = order.Map(o => new OrderDto()
        {
            Amount = o.Amount,
            Status = o.Status,
            Type = o.GetType().Name
        });

        Console.WriteLine($"{orderDto.Type} - {orderDto.Amount} - {orderDto.Status}");

        // 不限类型使用，使用委托回调，自定义逻辑
        int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        var result = arr.Map(a =>
        {
            string str = "";
            foreach (var i in a)
            {
                str += i;
            }

            return str;
        });

        Console.WriteLine(result);


        // var order = new StoreOrder(123);
        // var orderDto= order.Map();
        // Console.WriteLine($"{orderDto.Type} - {orderDto.Amount} - {orderDto.Status}");

        /*
        // 存储Order
        var orderRepo = new Repository<Order>();
        orderRepo.Add(new OnlineOrder(123,fakePaymentGateway));
        orderRepo.Add(new StoreOrder(456).PayNow());
        var orders=orderRepo.GetAll();
        foreach (var order in orders)
        {
            Console.WriteLine($"order Amount: {order?.Amount}, Status: {order?.Status}");
        }

        // 也可以存储其他类型： 比如Invoice
        var invoiceRepo = new Repository<Invoice>();
        invoiceRepo.Add(new Invoice("abc-123",2000));
        invoiceRepo.Add(new Invoice("efg-345",4000));
        var invoices=invoiceRepo.GetAll();
        foreach (var invoice in invoices)
        {
            Console.WriteLine($"invoice N0: {invoice.InvoiceNo} Amount: {invoice?.Amount}, Status: {invoice?.IsPaid}");
        }
        */

        /*
        var repo = new OrderRepository();

        repo.Add(new OnlineOrder(123, fakePaymentGateway));
        repo.Add(new StoreOrder(456).PayNow());

        var order = repo.GetById(1);
        Console.WriteLine($"my order Id: {order?.Id}, Amount: {order?.Amount}, Status: {order?.Status}");

        var orders = repo.GetAll();
        foreach (var o in orders)
        {
            Console.WriteLine($"order Id: {o.Id}, Amount: {o.Amount}, Status: {o.Status}");
        }
        */
    }
}