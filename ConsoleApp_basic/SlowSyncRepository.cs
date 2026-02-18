namespace ConsoleApp_basic;

public class SlowSyncRepository<T>:IRepository<T> where T: IHasId
{
    private readonly List<T> _items= [];
    
    public void Add(T item)
    {
        // 模拟慢 IO：阻塞线程 3 秒
        Thread.Sleep(3000);
        _items.Add(item);
    }

    public List<T> GetAll()
    {
        // 模拟慢 IO：阻塞线程 3 秒
        Thread.Sleep(3000);
        return _items;
    }
    
    public Result<T?> GetById(int id)
    {
        // 模拟慢 IO：阻塞线程 3 秒
        Thread.Sleep(3000);
        var found = _items.Find(x => x.Id == id);
        return found is null ? Result<T>.Fail("Not found") : Result<T>.Success(found);
    }
}