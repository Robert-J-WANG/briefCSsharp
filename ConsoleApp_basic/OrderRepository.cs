namespace ConsoleApp_basic;

public class OrderRepository
{
    private readonly List<Order> _orders= []; // 使用新语法

    public void Add(Order order) => _orders.Add(order);

    public Order? GetById(int? id) => _orders.Find(o => o.Id == id);

    public List<Order> GetAll() => [.._orders]; // 类似于js中的展开运算符
}