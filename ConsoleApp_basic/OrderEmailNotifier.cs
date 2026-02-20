namespace ConsoleApp_basic;

public class OrderEmailNotifier: IOrderNotifier
{
    public void NotifyPaid(Order order)
        => Console.WriteLine($"[SendEmail] Order {order.Id} paid, amount={order.Amount}");
}