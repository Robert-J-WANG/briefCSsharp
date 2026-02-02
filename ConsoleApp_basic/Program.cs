// 命名空间：组织标识代码，防止代码冲突，类似理解哪个班级的张三？？
namespace ConsoleApp_basic;

// Program类， 所有代码都会放在内存中开辟的Program区域中执行
class Program
{
    // 程序的入口方法，所以代码运行的逻辑都放在这个方法里执行
    static void Main()
    {
        // 1. 整数 int
        int age = 18; // 声明并初始化变量，局部变量：只在Main方法内部作用
        age = -18; // int有符号
        
        // 2. 小数 double
        double num = 18.555;
        num = -123.345; // double有符号
        
        // float: 需要结尾加f标识
        float num2 = 123.456f; 
        
        // decimal:需要结尾加m标识
        decimal num3 = 123.456m;
        
        // 3. bool 类型
        bool flag = true; 
        flag = false; // bool类型的值只能是true和false
        
        // 4. char 类型
        char c = 'A';
        // c = "A";
        // c = 'ab';
        
        // 5. string类型
        string str = "Hello World";
        
        // 控制台打印变量值: 使用字符串插值
        Console.WriteLine($"age: {age}, num: {num}, num2: {num2}, num3:{num3}, flag: {flag}, c: {c}, str:{str}");
        
        // 6. var - 动态类型
        // var a; // 必须要初始化，否则无法推导类型
        var a = 1;
        // a = true; // 类型推导完成，就固定了，不能再改类型
        // 不要滥用var, 除非比较麻烦的时候
        // List<Dictionary<string, int>> list = new List<Dictionary<string, int>>();
        var list = new List<Dictionary<string, int>>();

        // 7. 作用域
        {
            int b = 1;
            Console.WriteLine(b);
        }
        {
            int b = 2;
            Console.WriteLine(b);
        }
    }
}