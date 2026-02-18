namespace ConsoleApp_basic;

public class AsyncRepository<T>: IAsyncRepository<T>  where T: IHasId
{
    private readonly List<T> _items =[];
    
    public async Task  AddAsync (T item)
    {
        // 模拟 IO 延迟（比如写数据库）
        await Task.Delay(3000);
        _items.Add(item);
    }

    public async Task<List<T?>> GetAllAsync()
    {
        // 模拟 IO 延迟（比如写数据库）
        await Task.Delay(3000);
        return  [.._items];
    }
    
    public async Task<Result<T?>> GetByIdAsync(int id)
    {
        // 模拟 IO 延迟（比如写数据库）
        await Task.Delay(3000);
        var found = _items.Find(x => x.Id == id);
        return found is null ? Result<T?>.Fail("Not found") : Result<T?>.Success(found);
    }
}