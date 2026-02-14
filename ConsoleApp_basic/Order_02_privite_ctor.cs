namespace ConsoleApp_basic;

public class Order_02_privite_ctor
{
    private decimal _amount;
    private string _status;

    public Order_02_privite_ctor(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount must be greater than 0.", nameof(amount));
        }

        _amount = amount;
        _status = "Created";
    }

    public decimal Amount => _amount;
    public string Status => _status;
}