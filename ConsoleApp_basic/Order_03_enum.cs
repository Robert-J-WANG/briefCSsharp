namespace ConsoleApp_basic;

public class Order_03_enum
{
    private decimal _amount;
    private OrderStatus _status;

    public Order_03_enum(decimal amount)
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
}