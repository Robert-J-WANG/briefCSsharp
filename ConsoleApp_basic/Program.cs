namespace ConsoleApp_basic;

class Program
{
    class MyMethod
    {
        //成员（实例）方法
        // public void Greet()
        // {
        //     Console.WriteLine("Hello World!");
        // }
        
        public void Greet()=> Console.WriteLine("Hello World!");
       
        //静态方法
        // public static void Greet2()
        // {
        //     Console.WriteLine("Hello World too!");
        // }
        //
        public static void Greet2() => Console.WriteLine("Hello World too!");
       

        /*
         * 加密方法
         */
        // public static int Encrypt(int x)
        // {
        //     return x * 2 + 4;
        // }
        //
        public static int Encrypt(int x)=>x * 2 + 4;

        /*
         * 解密方法
         */
        // public static int Decrypt(int x)
        // {
        //     return (x - 4) / 2;
        // }
        public static int Decrypt(int x)=>(x - 4) / 2;

    }
    
    
    static void Main()
    {
        // 使用成员（实例）方法
        MyMethod m = new MyMethod();
        m.Greet();
        
        // 使用静态方法
        MyMethod.Greet2();
        
        // 加密一个数字
        int number = 100;
        int result=MyMethod.Encrypt(number);
        Console.WriteLine($"加密后的数字是{result}");
        
        // 解密一个数字
        int result2 = MyMethod.Decrypt(result);
        Console.WriteLine($"解密后的数字是{result2}");
    }
}