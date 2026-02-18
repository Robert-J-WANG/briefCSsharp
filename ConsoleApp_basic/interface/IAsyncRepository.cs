namespace ConsoleApp_basic;

public interface IAsyncRepository<T>
{
    Task AddAsync(T item);
    Task<List<T?>> GetAllAsync();
    Task<Result<T?>> GetByIdAsync(int id);
}