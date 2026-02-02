namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        double d = 1.234;
        float f = 234.123f;
        d = f;
        // f = d; // double的范围更大。无法隐式转化为float
        f = (float)d; // 显式强制转换

        int i = 123;
        short s = 456;
        i = s;
        // s = i; // int 的范围更大,无法隐式转化为short
        s = (short)i; // 显式强制转换

        bool connected = true;
        bool unconnected = false;
        int c = Convert.ToInt32(connected);
        int u = Convert.ToInt32(unconnected);
        Console.WriteLine($"c={c}, u={u}");

        connected = Convert.ToBoolean(c);
        unconnected = Convert.ToBoolean(u);
        Console.WriteLine($"connected={connected}, unconnected={unconnected}");

        int ii = 123456;
        string int_str = ii.ToString();
        int.TryParse(int_str, out int str_int);
        Console.WriteLine($"int_str={int_str}, str_int={str_int}");
        
        bool flag = true;
        string bool_str = flag.ToString();
        bool.TryParse(bool_str, out bool str_bool);
        Console.WriteLine($"bool_str={bool_str}, str_bool={str_bool}");

    }
}