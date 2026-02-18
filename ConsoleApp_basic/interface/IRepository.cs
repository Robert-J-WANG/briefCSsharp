namespace ConsoleApp_basic;

public interface IRepository<T> where T: IHasId
{
    void Add(T item);
    List<T> GetAll();
    // T? GetById(int id);
    Result<T> GetById(int id);
}