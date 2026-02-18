namespace ConsoleApp_basic;

public class OrderDto
{
    public decimal Amount { get; set; }
    public OrderStatus Status { get; set; }
    public string Type { get; set; } = "";
}