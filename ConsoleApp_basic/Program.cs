namespace ConsoleApp_basic;

class Program
{
    class Person
    {
        public string _name;
        public int _age;
        
        // 构造器方法，通过传参的方式创建实例对象
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }
    
    static void SetAge(Person person, int age)=> person._age = age;
    static void SetInt(int m, int  n) => m = n;

    public static double Example(double d)
    {
        double e = d;
        return e;
    }

    static void Main()
    {
        var person = new Person("John", 22);
        var person2 = person;
        person._age = 33;
        Console.WriteLine($"person is {person._name},  age is {person._age}");
        Console.WriteLine($"person2 is {person2._name},  age is {person2._age}");
        
        
        SetAge(person2,44);
        Console.WriteLine($"person is {person._name},  age is {person._age}");
        Console.WriteLine($"person2 is {person2._name},  age is {person2._age}");

        int m = 100;
        SetInt(m,0);
        Console.WriteLine($"the value is {m}");

        double result = Example(2.1415926);

        string str = null; // 引用类型可以赋值为空
        // int i = null; //值类型不能为空
        int? i = null; // 加？设置为可空值
    }
}