// namespace ConsoleApp_basic;
//
// public enum OrderStatus
// {
//     Created = 0,
//     Paid = 1
// } 
//
// // public delegate void PaymentSucceededHandler(Order order);
//
// public abstract class Order: IPayable
// {
//  
//     
//     // 子类需要用到，所以 protected
//     protected decimal _amount;
//     protected OrderStatus _status;
//     
//     // 子类需要继承的委托
//     public Action<Order> OnSuccess;
//
//     protected Order(decimal amount)
//     {
//         if (amount < 0)
//         {
//             throw new ArgumentException("Amount must be greater than 0.", nameof(amount));
//         }
//
//         _amount = amount;
//         _status = OrderStatus.Created;
//     }
//
//     public decimal Amount => _amount;
//     public OrderStatus Status => _status;
//     
//     // 抽象pay方法， 不给默认实现，强制子类实现
//     public abstract void Pay();
//
//    
//     
//     // 但父类依然可以提供“共享的校验工具”
//     protected void EnsureCanPay()
//     {
//         if (_status != OrderStatus.Created)
//             throw new InvalidOperationException("Only a Created order can be paid.");
//     }
//     
//     protected void HandlePaymentSucceeded()
//     {
//         // 3. 触发委托（注意：基础阶段要判断是否为 null）
//         if (OnSuccess != null) 
//         {
//             OnSuccess(this);
//         }
//     }
//
// }