namespace ConsoleApp_basic;

public class Repository<T>: IRepository<T>  where T: IHasId
{
    private readonly List<T> _items =[];
    
    public void  Add(T item) => _items.Add(item);

    public List<T> GetAll() => [.._items];
    
    public Result<T> GetById(int id)
    {
        var found = _items.Find(x => x.Id == id);
        return found is null ? Result<T>.Fail("Not found") : Result<T>.Success(found);
    }
}