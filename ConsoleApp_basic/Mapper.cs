namespace ConsoleApp_basic;

public static class Mapper
{
    
    public static TResult Map<TResult,TSource>(this TSource source, Func<TSource, TResult> mapper)
    {
        if (mapper == null) throw new ArgumentNullException(nameof(mapper));
        return mapper(source);
    }
    
    // public static TResult Map<TResult,TSource>(this TSource source, Func<TSource, TResult> mapper)
    // {
    //     if (mapper == null) throw new ArgumentNullException(nameof(mapper));
    //     return mapper(source);
    // }
    
    // public static OrderDto Map(this Order order, Func<Order, OrderDto> mapper)
    // {
    //     if (mapper == null) throw new ArgumentNullException(nameof(order));
    //     return mapper(order);
    // }
    
    
    // public static OrderDto Map(this Order order)
    // {
    //     if (order == null) throw new ArgumentNullException(nameof(order));
    //     
    //     return new OrderDto()
    //     {
    //         Amount = order.Amount,
    //         Status = order.Status,
    //         Type = order.GetType().Name,
    //     };
    // }
}