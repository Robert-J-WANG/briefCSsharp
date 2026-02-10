using System.Globalization;

namespace ConsoleApp_basic;

class Program
{
    static int Add(int a) => a + 1;
    static int Add(int a, int b) => a + b;
    static double Add(int a, double b) =>a+b;
    
    
    
    // static void Add(int a, int b)=>Console.WriteLine(a + b);
    // static int Add(int a, int b=1) => a + b;
    
    static void Print(int a)=> Console.WriteLine(a);

    static void Change(ref int a, in int b)
    {
        a++;
        // b++; // 报错，只读不能改
        
    }

    static void UnChange(int a, int b)
    {
        a++;
        b++;
    }

    static bool IsEqual(ref int num, out int copy)
    {
        copy = num;
        num++;
        return copy == num ? true : false;

    }

    static int AddMore(int a, params int [] nums)
    {
        int r = a;
        foreach (var n in nums)
        {
            r += n;
        }
        return r;
    }

    static void Main()
    {
        Console.WriteLine(Add(1, 2));
        Console.WriteLine(Add(1));
        Console.WriteLine(Add(b:2,a:3));
        Console.WriteLine(AddMore(1, 2,3,4,5));

        int a = 1;
        int b = 2;
        UnChange(a,b);
        Console.WriteLine($"a:{a}, b:{b}");
        Change(ref a, b);
        Console.WriteLine($"a:{a}, b:{b}");

        int num = -1;
        bool result= IsEqual(ref num, out int copy);
        Console.WriteLine($"result:{result}, num:{num}, copy:{copy}");
    }
}