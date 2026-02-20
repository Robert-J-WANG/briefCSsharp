
namespace ConsoleApp_basic;

public enum Lifetime
{
    Transient,
    Singleton
}
public class SimpleContainer
{
    

    private class Registration
    {
        public Type ServiceType { get; init; } = default!;
        public Type? ImplType { get; init; }
        public Lifetime Lifetime { get; init; }

        public object? SingletonInstance { get; set; }
        public object? Instance { get; init; }
    }

    private readonly Dictionary<Type, Registration> _map = new();

    // 1) 注册：接口/抽象 → 实现
    public void Register<TService, TImpl>(Lifetime lifetime = Lifetime.Transient)
        where TImpl : TService
    {
        _map[typeof(TService)] = new Registration
        {
            ServiceType = typeof(TService),
            ImplType = typeof(TImpl),
            Lifetime = lifetime
        };
    }

    // 2) 注册：现成实例
    public void RegisterInstance<TService>(TService instance)
    {
        if (instance == null) throw new ArgumentNullException(nameof(instance));

        _map[typeof(TService)] = new Registration
        {
            ServiceType = typeof(TService),
            Instance = instance!,
            Lifetime = Lifetime.Singleton,
            SingletonInstance = instance!
        };
    }

    // 3) 解析：对外入口（泛型版本）
    public TService Resolve<TService>()
        => (TService)Resolve(typeof(TService));

    // 解析：内部统一入口（非泛型）
    private object Resolve(Type serviceType)
    {
        // 如果没有注册
        if (!_map.TryGetValue(serviceType, out var reg))
        {
            // 允许“具体类”不注册也能被创建（容器直接 new 它）
            // 但接口/抽象类必须注册，否则无法 new
            if (serviceType.IsInterface || serviceType.IsAbstract)
                throw new InvalidOperationException($"Type not registered: {serviceType.FullName}");

            return Create(serviceType);
        }

        // 如果是 RegisterInstance：直接返回
        if (reg.Instance != null)
            return reg.Instance;

        // 如果是 Singleton：有缓存就返回，没有就创建并缓存
        if (reg.Lifetime == Lifetime.Singleton)
        {
            if (reg.SingletonInstance != null)
                return reg.SingletonInstance;

            reg.SingletonInstance = Create(reg.ImplType!);
            return reg.SingletonInstance;
        }

        // Transient：每次都创建新对象
        return Create(reg.ImplType!);
    }

    // 创建对象：核心逻辑——找构造器 + 解析参数 + Activator new
    private object Create(Type implType)
    {
        // 选一个构造器策略：这里选“参数最多的构造器”
        // 原因：通常依赖会放在构造器参数里，参数最多意味着依赖最完整
        var ctor = implType.GetConstructors()
            .OrderByDescending(c => c.GetParameters().Length)
            .FirstOrDefault();

        if (ctor == null)
            throw new InvalidOperationException($"No public constructor found for {implType.FullName}");

        // 对构造器每个参数进行 Resolve（递归构建依赖树）
        var parameters = ctor.GetParameters();
        var args = new object[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            args[i] = Resolve(parameters[i].ParameterType);
        }

        // 真正创建对象
        return Activator.CreateInstance(implType, args)
               ?? throw new InvalidOperationException($"Failed to create instance of {implType.FullName}");
    }
}
