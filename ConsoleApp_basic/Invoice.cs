namespace ConsoleApp_basic;

public class Invoice : IPayable
{
    private string _invoiceNo;
    private decimal _amount;
    private bool _isPaid;

    public Invoice(string invoiceNo, decimal amount)
    {
        if (string.IsNullOrWhiteSpace(invoiceNo))
        {
            throw new ArgumentException("InvoiceNo is required.", nameof(invoiceNo));
        }

        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
        }

        _invoiceNo = invoiceNo;
        _amount = amount;
        _isPaid = false;
    }


    public string InvoiceNo => _invoiceNo;
    public decimal Amount => _amount;
    public bool IsPaid => _isPaid;

    public void Pay()
    {
        if (_isPaid)
            throw new InvalidOperationException("Invoice has already been paid.");

        Console.WriteLine($"[Invoice] Paid invoice {_invoiceNo}, amount={_amount}");
        _isPaid = true;
    }
}