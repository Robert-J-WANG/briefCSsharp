namespace ConsoleApp_basic;

public class Order_04_method
{
    private decimal _amount;
    private OrderStatus _status;

    public Order_04_method(decimal amount)
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

    public void Pay()
    {
        if (_status != OrderStatus.Created)
        {
            throw new InvalidOperationException("Only created orders can be paid.");
        }

        _status = OrderStatus.Paid;
    }
}